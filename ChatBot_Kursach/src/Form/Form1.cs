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
        int prevMessage = 0;
        string inputString;

        public ChatBot()
        {
            InitializeComponent();

            //panel1.Left = 15;
            //textBox1.Left = 15;
            //button_send.Left = 15 + 6 + textBox1.Width;
        }

       

        private void createOutBouble()
        {
            panel1.VerticalScroll.Value = 0;
            panel1.PerformLayout();

            PictureBox pic = new PictureBox();
            Panel tmp = new Panel();
            Label lab = new Label();

            tmp.Parent = panel1;
            lab.Parent = tmp;
            pic.Parent = tmp;

            tmp.Controls.Add(lab);
            tmp.Controls.Add(pic);
            panel1.Controls.Add(tmp);

            tmp.Location = new System.Drawing.Point(10, 20 + prevMessage);
            tmp.BackColor = System.Drawing.Color.FromArgb(255, 240, 240, 240);
            tmp.BringToFront();
            tmp.AutoSize = true;
            tmp.MaximumSize = new System.Drawing.Size(panel1.Width - 20, 0);

            lab.Location = new System.Drawing.Point(5, 5);
            lab.AutoSize = true;
            lab.MaximumSize = new System.Drawing.Size(tmp.Width - 20, 0);
            lab.Margin = new Padding(5);
            lab.Text = algorithmClass.GetText();

            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Size = new System.Drawing.Size(tmp.Width - 20, 10);
            pic.Location = new System.Drawing.Point((tmp.Width - pic.Width) / 2, 5);

            switch (algorithmClass.ImagePath)
            {
                case (int)Constants.Images.NULL:
                    {
                        lab.Top = 5;
                        pic.Image = null;
                        pic.Height = 0;
                        break;
                    }
                case (int)Constants.Images.ROBOT:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.robot;
                        break;
                    }
                case (int)Constants.Images.SEND:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.send;
                        break;

                    }
                case (int)Constants.Images.HEART:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.heart_disabled;
                        break;
                    }
                case (int)Constants.Images.LEUVEN:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.KULeuven;
                        break;
                    }
                case (int)Constants.Images.ILMENAU:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.ilmenau;
                        break;
                    }
                case (int)Constants.Images.DORTMUND:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Dortmund;
                        break;
                    }
                case (int)Constants.Images.MADRID:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Madrid_Politech;
                        break;
                    }
                case (int)Constants.Images.KARINT:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Karint_Univ;
                        break;
                    }
                case (int)Constants.Images.ARTESIS:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Artests_Plantijn;
                        break;
                    }
                case (int)Constants.Images.THOMAS:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Thomas_More;
                        break;
                    }
                case (int)Constants.Images.TRANSILVANIA:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Transilvania;
                        break;
                    }
                case (int)Constants.Images.TRANSILVANIA_MAP:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Transilvania_Map;
                        break;
                    }
                ////
                case (int)Constants.Images.THOMAS_MAP:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Thomas_Map;
                        break;
                    }
                case (int)Constants.Images.MADRID_MAP:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Madrid_Map;
                        break;
                    }
                case (int)Constants.Images.KARINT_MAP:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Karintia_Map;
                        break;
                    }
                case (int)Constants.Images.ILMENAU_MAP:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Ilmanua_Map;
                        break;
                    }
                case (int)Constants.Images.LEUVEN_MAP:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Leuven_Map;
                        break;
                    }
                case (int)Constants.Images.DORTMUND_MAP:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Dortmund_Map;
                        break;
                    }
                case (int)Constants.Images.ARTESIS_MAP:
                    {
                        lab.Top += 150;
                        pic.Height = lab.Top - 10;
                        pic.Image = Properties.Resources.Artesis_Map;
                        break;
                    }
                ////
                default:
                    {
                        lab.Top = 5;
                        pic.Height = 0;
                        pic.Image = null;
                        break;
                    }
            }

            prevMessage += tmp.Height + 20;

            Label Padd = new Label();
            panel1.Controls.Add(Padd);
            Padd.Height = 10;
            Padd.Location = new System.Drawing.Point(10, prevMessage);

            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            panel1.PerformLayout();
        }

        private void createInBouble()
        {
            panel1.VerticalScroll.Value = 0;
            panel1.PerformLayout();

            Panel tmpin = new Panel();
            Label labin = new Label();

            tmpin.Parent = panel1;
            labin.Parent = tmpin;

            tmpin.Controls.Add(labin);
            panel1.Controls.Add(tmpin);

            labin.Location = new System.Drawing.Point(0, 5);
            labin.Margin = new Padding(5);
            labin.AutoSize = true;
            labin.Text = inputString;
            labin.MaximumSize = new System.Drawing.Size(panel1.Width - 40, 0);

            tmpin.BackColor = System.Drawing.Color.FromArgb(255, 215, 255, 222);
            tmpin.MaximumSize = new System.Drawing.Size(labin.Width, labin.Height + 10);
            tmpin.AutoSize = true;
            tmpin.BringToFront();
            tmpin.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tmpin.Location = new System.Drawing.Point(panel1.Width - tmpin.Width - 20, 10 + prevMessage);



            prevMessage += tmpin.Height + 10;

        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            inputString = textBox1.Text.ToString();
            if (inputString.Equals(""))
            {
                return;
            }

            algorithmClass.CheckKeyWord(inputString);
            textBox1.Text = "";

            createInBouble();
            createOutBouble();
            

            /*button2.Visible = algorithmClass.IsButtonVisible;
            if (button2.Visible && algorithmClass.IsButtonLiked) button2.Image = Properties.Resources.heart_enabled;
                else button2.Image = Properties.Resources.heart_disabled;*/
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            algorithmClass.ClearFav();
            

            //fileClass.erase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createOutBouble();
        }


        private void проДодатокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void ChatBot_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
        }

        private void ChatBot_ResizeEnd(object sender, EventArgs e)
        {
            ResumeLayout();
        }

        private void ChatBot_FormClosed(object sender, FormClosedEventArgs e)
        {
            WorkWithFiles.JSONFile.SaveInfo("favorites");
        }

    }
}
