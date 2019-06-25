using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhramaCare
{

    static class Connexion // WE CREATE THIS TO HAVE GLOBAL VARIABLES FOR CONNEXION
    {
        public static string User_id { get; set; }
        
    }

    static class Variable // SOLUTION WE FOUND TO USE A VARIABLE FROM FORM TO FORM
    {
        public static string Medic_selected { get; set; }

    }


    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIContainer());
            Application.Run(new AlgoMedics());
            Application.Run(new UserProfil());
        }
    }
}
