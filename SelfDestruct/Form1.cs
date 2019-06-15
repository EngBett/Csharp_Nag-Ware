using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace SelfDestruct
{
    public partial class Form1 : Form
    {
        private int seconds, minutes, key = 0, token, keyClose = 0;
        private string killerCode = "12";
        public Form1()
        {
            this.seconds = 22;
            this.minutes = 0;
            InitializeComponent();
            player.Hide();
            player.URL = "./tones/initiated.mp3";
            display();
            timer.Start();
        }

        private void display()
        {
            string ds, dm;
            if (this.seconds < 10)
            {
                ds = "0" + this.seconds.ToString();
            }
            else
            {
                ds = this.seconds.ToString();
            }
            if (this.minutes < 10)
            {
                dm = "0" + this.minutes.ToString();
            }
            else
            {
                dm = this.minutes.ToString();
            }
            

            displayLbl.Text = dm + ":" + ds;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.countDown();
            if (this.minutes == 0 && this.seconds == 0)
            {
                timer.Stop();
                Application.Exit();
            }
            if (this.minutes * this.seconds <= 8 || this.minutes * this.seconds == 0 && !(minutes == 0 && seconds < 20))
            {
                if(this.killerCode.Length <= 12)
                {
                    //this.loading(this.seconds);
                    sdsLbl.Hide();
                    this.display();
                    if (minutes == 0 && seconds < 20 && seconds>= 15)
                    {
                        Console.Beep(3500, 90);
                        Console.Beep(3500, 90);
                  
                    }
                    else if (minutes == 0 && seconds < 15 && seconds >= 10)
                    {
                        Console.Beep(3500, 170);
                        Console.Beep(3500, 170);
                        Console.Beep(3500, 170);
                    }
                    else if (minutes == 0 && seconds < 10 && seconds >= 5)
                    {
                        Console.Beep(3500, 200);
                        Console.Beep(3500, 200);
                        Console.Beep(3500, 200);
                        Console.Beep(3500, 200);
                        Console.Beep(3500, 200);
                    }
                    else if (minutes == 0 && seconds < 5)
                    {
                        if (keyClose == 0)
                        {
                            Console.Beep(3500, 200);
                            keyClose = 1;
                        }
                    }
                    else
                    {
                        Console.Beep(1500, 100);
                    }
                    
                }
                else
                {
                    if (this.key == 0)
                    {
                        player.URL = "./tones/terminated.mp3";
                        sdsLbl.Show();
                        sdsLbl.Text = "Self Destruct Sequence Terminated";
                        if (this.minutes < 1)
                        {
                            this.token = this.seconds;
                        }
                        else
                        {
                            this.token = 60 + this.seconds;
                        }
                        this.key = 1;
                    }
                    if (this.token - this.second(this.minutes, this.seconds) > 3)
                    {
                        timer.Stop();
                        Application.Exit();
                    }
                }
            }
            else 
            {
                Console.Beep(1500, 100);
                this.display();
            }
            
        }

        private void loading(int s)
        {
            if (s % 4 == 0)
            {
                sdsLbl.Text = "Self Destruct Sequence Initiated...";
            }
            else if(s % 4 == 1)
            {
                sdsLbl.Text = "Self Destruct Sequence Initiated..";
            }
            else if (s % 4 == 2)
            {
                sdsLbl.Text = "Self Destruct Sequence Initiated.";
            }
            else
            {
                sdsLbl.Text = "Self Destruct Sequence Initiated";
            }
        }

        private void countDown()
        {
            this.seconds -= 1;
            if (this.seconds < 0)
            {
                this.seconds = 59;
                this.minutes -= 1;
            }
        }

        private int second(int min, int sec)
        {
            if(min < 1)
            {
                return sec;
            }
            else
            {
                return 60 + sec;
            }
        }

        private void killCode_OnValueChanged(object sender, EventArgs e)
        {
            //this.killerCode = killCode.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
