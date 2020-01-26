using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace bc_system
{
    
    static class Program
    {
       

        public static string username; //global in app)
        public static string user; //global in forget mass)
        public static string Id;
        public static int no;

     //   public static string cmb1;
     

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }
}
