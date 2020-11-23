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
                case (int)Constants.Images.ROBOT:          pictureBox1.Image = Properties.Resources.robot; break;
                case (int)Constants.Images.SEND:           pictureBox1.Image = Properties.Resources.send; break;
                case (int)Constants.Images.HEART:          pictureBox1.Image = Properties.Resources.heart_disabled; break;
                case (int)Constants.Images.LEUVEN:         pictureBox1.Image = Properties.Resources.KULeuven; break;
                case (int)Constants.Images.ILMENAU:        pictureBox1.Image = Properties.Resources.ilmenau; break;
                case (int)Constants.Images.DORTMUND:       pictureBox1.Image = Properties.Resources.Dortmund; break;
                case (int)Constants.Images.MADRID:         pictureBox1.Image = Properties.Resources.Madrid_Politech; break;
                case (int)Constants.Images.KARINT:         pictureBox1.Image = Properties.Resources.Karint_Univ; break;
                case (int)Constants.Images.ARTESIS:        pictureBox1.Image = Properties.Resources.Artests_Plantijn; break;
                case (int)Constants.Images.THOMAS:         pictureBox1.Image = Properties.Resources.Thomas_More; break;
                case (int)Constants.Images.TRANSILVANIA:   pictureBox1.Image = Properties.Resources.Transilvania; break;
                default:                         pictureBox1.Image = Properties.Resources.robot; break;
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
            pictureBox1.Image = Properties.Resources.robot;
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
    }
}
