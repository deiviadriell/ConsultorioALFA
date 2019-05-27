using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CONSULTORIO_ALFA_V._1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm_login frm_login = new _1.frm_login();
            frm_login.ShowDialog(); 
            if(!frm_login.salio())
            Application.Run(new frm_principal());
        }
    }
}
