using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LgConfig.SetLanguage();
            FrmLogin flog = new FrmLogin();
            DialogResult showLogin = flog.ShowDialog();
            if (showLogin != DialogResult.OK)
            {
                goto TheEnd;
            }

            long idUser = flog.GetId;
            string fullName = flog.FullName;
            string userName = flog.UserName;
            long idLogin = flog.GetIdLogin;

            Application.Run(new FrmMain(idUser, fullName, userName, idLogin));
        TheEnd:
            return;
        }
    }
}
