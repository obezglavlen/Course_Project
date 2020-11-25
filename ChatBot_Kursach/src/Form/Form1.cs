using ChatBot_Kursach.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatBot_Kursach.Algorithms;

namespace ChatBot_Kursach.MainForm
{
    public partial class ChatBot : Form
    {
        //
        // Добавление екземпляра класса MainClass
        //
        MainClass algorithmClass = new MainClass();


        public ChatBot()
        {
            InitializeComponent();
            ResizeText();

            //panel1.Left = 15;
            //textBox1.Left = 15;
            //button_send.Left = 15 + 6 + textBox1.Width;
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            string inputString = textBox1.Text.ToString();
            if (inputString.Equals(""))
            {
                return;
            }
            algorithmClass.CheckKeyWord(inputString);
            label1.Text = algorithmClass.GetText();
            textBox1.Text = "";
            button2.Visible = algorithmClass.IsButtonVisible; // true or false
            switch (algorithmClass.ImagePath)
            {
                case (int)Constants.Images.NULL:
                    {
                        label1.Top = 5;
                        pictureBox1.Image = null;
                        pictureBox1.Height = 0;
                        break;
                    }
                case (int)Constants.Images.ROBOT:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.robot;
                        break;
                    }          
                case (int)Constants.Images.SEND:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.send;
                        break;

                    }
                case (int)Constants.Images.HEART:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.heart_disabled;
                        break;
                    }
                case (int)Constants.Images.LEUVEN:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.KULeuven;
                        break;
                    }
                case (int)Constants.Images.ILMENAU:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.ilmenau;
                        break;
                    }
                case (int)Constants.Images.DORTMUND:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.Dortmund;
                        break;
                    }
                case (int)Constants.Images.MADRID:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.Madrid_Politech;
                        break;
                    }
                case (int)Constants.Images.KARINT:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.Karint_Univ;
                        break;
                    }
                case (int)Constants.Images.ARTESIS:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.Artests_Plantijn;
                        break;
                    }
                case (int)Constants.Images.THOMAS:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.Thomas_More;
                        break;
                    }
                case (int)Constants.Images.TRANSILVANIA:
                    {
                        ResizePictureBox();
                        pictureBox1.Image = Properties.Resources.Transilvania;
                        break;
                    }
                default:
                    {
                        label1.Top = 5;
                        pictureBox1.Height = 0;
                        pictureBox1.Image = null;
                        break;
                    }
            }   
            button2.Visible = algorithmClass.IsButtonVisible;
            if (button2.Visible && algorithmClass.IsButtonLiked) button2.Image = Properties.Resources.heart_enabled;
                else button2.Image = Properties.Resources.heart_disabled;
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            algorithmClass.ClearFav();
            //fileClass.erase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = algorithmClass.Init().Text;
            //pictureBox1.Image = Properties.Resources.robot;
            button2.Visible = false;
        }

        private void HeartClick(object sender, EventArgs e)
        {
            algorithmClass.SetFavActive();
            if(algorithmClass.IsButtonLiked) button2.Image= Properties.Resources.heart_enabled;
            else button2.Image= Properties.Resources.heart_disabled;
        }

        private void проДодатокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }



        private void ResizePictureBox()
        {
            label1.Top += 220;
            pictureBox1.Height = label1.Top - 10;
        }

        private void ResizeText()
        {
            label1.MaximumSize = new System.Drawing.Size(panel1.Width - 15, 0);
        }

        private void ChatBot_Resize(object sender, EventArgs e)
        {
            ResizeText();
        }

        private void ChatBot_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
        }

        private void ChatBot_ResizeEnd(object sender, EventArgs e)
        {
            ResumeLayout();
        }
    }
}
