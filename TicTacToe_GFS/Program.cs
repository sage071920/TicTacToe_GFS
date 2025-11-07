using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TicTacToe_GFS
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
            
            Steuerung steuerung = new Steuerung();
            Oberfläche dieGui = new Oberfläche(steuerung);
            // Erstelle Steuerung und starte deren GUI
            Application.Run(dieGui);
        }
    }
}