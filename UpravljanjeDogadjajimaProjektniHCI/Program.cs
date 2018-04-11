using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpravljanjeDogadjajimaProjektniHCI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult loginRezultat;
            using (var loginForma = new LoginForma())
                loginRezultat = loginForma.ShowDialog();
            if (loginRezultat == DialogResult.OK)
            {
                // login was successful
                Application.Run(new Isprobavanje());
            }
            
        }
    }
}
