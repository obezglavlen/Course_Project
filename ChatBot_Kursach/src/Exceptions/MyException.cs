using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Exceptions
{
    public class MyException : Exception
    {


        public string what { get; set; }

        public MyException(int code) : base()
        {
            switch(code){
                case 1:
                    /*                    System.Windows.Forms.Form form1 = ChatBot_Kursach.MainForm.ChatBot.ActiveForm;
                                        form1.Close();*/
                    what = "\n\nПомилка введення ключового слова";
                    break;

                default:
                    what = "усе погано";
                    InitAlert(what);
                    break;
            }
        }

        public MyException(Exception ex) 
        {

                    what = ex.Message;
                    InitAlert(what);

        }


        protected MyException() { }



        protected void InitAlert(string message)
        {
            Alert alert = new Alert(message);            
            alert.ShowDialog();
            
        }
    }
}
