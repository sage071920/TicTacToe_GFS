using System;
using System.Windows.Forms;

namespace TicTacToe_GFS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Steuerung steuerung = new Steuerung();  // Startet alles
            Application.Run(steuerung._dieGui);     // Zeigt das Formular
        }
    }
}