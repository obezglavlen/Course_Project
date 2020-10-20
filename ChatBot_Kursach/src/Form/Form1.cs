﻿using ChatBot_Kursach.Properties;
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
        // Добавление екземпляра класса MainClass
        //
        MainClass algorithmClass = new MainClass();

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = textBox1.Text.ToString();
            if (str.Equals(""))
            {
                return;
            }
            algorithmClass.CheckKeyWord(str);
            label1.Text = algorithmClass.GetText();
            textBox1.Text = "";
            //button2.Visible = algorithmClass.CheckButtonVisible(); // true or false
            switch (algorithmClass.ImagePath)
            {
                case "robot": pictureBox1.Image = Properties.Resources.robot; break;
                case "send": pictureBox1.Image = Properties.Resources.send; break;
                case "heart": pictureBox1.Image = Properties.Resources.heart_PNG704; break;
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fileClass.erase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = algorithmClass.Start().GetText();
            pictureBox1.Image = Properties.Resources.robot;
        }
    }
}
