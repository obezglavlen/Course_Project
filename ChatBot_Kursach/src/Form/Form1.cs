using ChatBot_Kursach.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatBot_Kursach.Algorithms;

namespace ChatBot_Kursach
{
    public partial class Form1 : Form
    {
        //
        // Добавление екземпляра класса Algorithm
        //
        Algorithm Test = new Algorithm();

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            Test.b = 331;
            string str = textBox1.Text;
            textBox2.Text = $"{Convert.ToString(Test.b)}" + $" + {str}"; // Конвертация Test.b в string и добавление к нему теста из поля ввода

            //pictureBox1.Image = (Image)Resource1.ResourceManager.GetObject(yourClass.getNeedImage());
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fileClass.erase();
        }
    }
}
