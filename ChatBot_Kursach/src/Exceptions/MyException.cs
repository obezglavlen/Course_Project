using System;


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
                    what = "Помилка введення ключового слова";
                    break;
                case 2:
                    what = "Невірна індексація в dynamicscreen";
                    Console.WriteLine(what,false);
                    break;

                default:
                    what = "усе погано";
                    WorkWithFiles.JSONFile.SaveInfo("favorites");
                    InitAlert(what,true);
                    break;
            }
        }

        public MyException(Exception ex) 
        {

                    what = ex.Message;
                    InitAlert(what, true);

        }


        protected MyException() { }



        protected void InitAlert(string message, bool Critical)
        {
            Alert alert = new Alert(message, Critical);            
            alert.ShowDialog();         
        }
    }
}
