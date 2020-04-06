using ContestFormApp.Services;
using System;
using System.Windows.Forms;
using ContestNetworking.Protocol;

namespace ContestFormApp
{
    static class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServerProxy serverProxy = new ServerProxy(55555, "127.0.0.1");
            ContestController controller = new ContestController(serverProxy);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm(controller));
        }
    }
}
