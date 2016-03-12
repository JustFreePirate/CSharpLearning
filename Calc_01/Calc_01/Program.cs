using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Calc_01
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
            Application.Run(new CalcForm());
            //Console.WriteLine("fdfdfdfdfdfdsfsdfshdfajkdgfadsh");
            //Console.WriteLine();
            //Console.WriteLine("fdfdfdfdfdfdsfsdfshdfajkdgfadsh");
        }
    }
}
