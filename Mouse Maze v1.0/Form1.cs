using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mouse_Maze_v1._0
{
    public partial class Form1 : Form
    {
        #region Değişkenler

        double yaşam;

        double u1, u2, stdNormal;
        int i = 0;
        int devir = 0;
        int kurtulan = 0,ölen=0;
        double dolaşım,toplamdolaşım,kurtulma;

        #endregion

        #region Tanımlamalar

        Random r = new Random();


        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            if (i<101)
            {
                textBox1.Text = (i).ToString();
                u1 = r.NextDouble();
                u2 = r.NextDouble();
                stdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
                yaşam = stdNormal * 2 + 9;

                devir = 0;
                dolaşım = 0;
                toplamdolaşım = 0;

                for (toplamdolaşım = 0; toplamdolaşım <= yaşam; )
                {
                    devir++;

                    if (devir % 2 != 0)
                    {
                        dolaşım = 1 + r.NextDouble() * 2;
                        kurtulma = r.NextDouble();

                        if (kurtulma <= 0.3)
                        {
                            toplamdolaşım += dolaşım;

                            if (toplamdolaşım <= yaşam)
                            {
                                kurtulan++;
                                pictureBox1.Image = Image.FromFile("kurtuluş.jpg");
                                break;
                            }

                            else
                            {
                                ölen++;
                                pictureBox1.Image = Image.FromFile("Ölü.jpg");
                                break;
                            }
                        }

                        else
                        {
                            toplamdolaşım += dolaşım;
                            if (toplamdolaşım > yaşam)
                            {
                                ölen++;
                                pictureBox1.Image = Image.FromFile("Ölü.jpg");
                                break;
                            }
                        }
                    }

                    else
                    {
                        dolaşım = 2 + r.NextDouble() * 2;
                        kurtulma = r.NextDouble();

                        if (kurtulma <= 0.3)
                        {
                            toplamdolaşım += dolaşım;

                            if (toplamdolaşım <= yaşam)
                            {
                                kurtulan++;
                                pictureBox1.Image = Image.FromFile("kurtuluş.jpg");
                                break;
                            }

                            else
                            {
                                ölen++;
                                pictureBox1.Image = Image.FromFile("Ölü.jpg");
                                break;
                            }
                        }

                        else
                        {
                            toplamdolaşım += dolaşım;
                            if (toplamdolaşım > yaşam)
                            {
                                ölen++;
                                pictureBox1.Image = Image.FromFile("Ölü.jpg");
                                break;
                            }
                        }
                    }

                }

                textBox2.Text = kurtulan.ToString();
                textBox3.Text = ölen.ToString();
            }

            else
            {
                timer1.Stop();
            }
           
               
        }
    }
}
