using OnePlusCalorie.UI.LoginRegister;

namespace OnePlusCalorie.UI
{
    internal static class Program
    {
        //public static LoginForm LoginForm { get; private set; }


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new LoginForm());

            //LoginForm = new LoginForm();




        }
    }
}