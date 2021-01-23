﻿using System;
using System.Windows.Forms;
using ChatBot_Kursach.MainForm;

namespace ChatBot_Kursach
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ChatBot ch = new ChatBot();
            Application.Run(ch);
        }

    }
}
