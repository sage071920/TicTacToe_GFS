using System.Runtime.Remoting.Contexts;

namespace TicTacToe_GFS
{
    public class Steuerung
    {
        private Oberfläche _dieGui;
        private Daten _dieDaten;
        private Statistik _dieStatistik;
        
        private char _aktSpieler = 'X';

        public Steuerung()
        {
            _dieGui = new Oberfläche(this); // Erstelle Oberfläche und übergib this als Parameter
            _dieDaten = new Daten();
            _dieStatistik = new Statistik();
        }
        
        public void setzeAktSpieler(char pSpieler)
        {
            if (pSpieler == 'X' || pSpieler == 'O')
            {
                _aktSpieler = pSpieler;
            }
        }
        
        public char ermittleAktSpieler()
        {
            return _aktSpieler;
        }
        
        public void bearbeiteClick(int pNr)
        {
            bool erfolgreich = _dieDaten.setzeFeld(pNr, ermittleAktSpieler());
            if (erfolgreich)
            {
                _dieGui.markiere(pNr, ermittleAktSpieler());
                // Spieler wechseln
                _aktSpieler = (_aktSpieler == 'X') ? 'O' : 'X';
            }
        }

        public void bearbeiteTaste(int pNr)
        {
            bool erfolgreich = _dieDaten.setzeFeld(pNr, ermittleAktSpieler());
            if (erfolgreich)
            {
                _dieGui.markiere(pNr, ermittleAktSpieler());
                // Spieler wechseln
                _aktSpieler = (_aktSpieler == 'X') ? 'O' : 'X';
            }
        }
    }
}
