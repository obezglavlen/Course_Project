﻿
using System;

using System.Windows.Forms;

namespace ChatBot_Kursach
{
    public partial class Alert : Form
    {
        bool critical;
        public Alert(string message, bool Critical)
        {
            InitializeComponent();
            critical = Critical;
            this.label2.Text = "Під час роботи програми виникла помилка:\n"+message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (critical)
            {
                Application.Exit();
                System.Environment.Exit(0);
            }
            this.Close();

        }

        private void Alert_Load(object sender, EventArgs e)
        {

        }
    }
}
