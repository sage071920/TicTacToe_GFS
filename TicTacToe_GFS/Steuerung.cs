using System;
using System.Runtime.Remoting.Contexts;

namespace TicTacToe_GFS
{
    public class Steuerung
    {
        public Oberfläche _dieGui;
        private Daten _dieDaten;
        private Statistik _dieStatistik;
        
        private char _aktSpieler;
        private int _anzahlZuege;

        public Steuerung()
        {
            Random r = new Random();
            _aktSpieler = r.Next(2) == 0 ? 'X' : 'O'; // Zufällig 'X' oder 'O'
            _dieGui = new Oberfläche(this); // Erstelle Oberfläche und übergib this als Parameter
            _dieGui.InitOberfläche();
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
                _dieGui.ausgabeText($"Spieler {ermittleAktSpieler()} ist am Zug"); // Labels aktualisieren

            }
        }

        public void bearbeiteTaste(int pNr)
        {
            bool erfolgreich = _dieDaten.setzeFeld(pNr, ermittleAktSpieler());
            if (erfolgreich)
            {
                _dieGui.markiere(pNr, ermittleAktSpieler());
                
                erhoeheAnzZuege();
                
                // Spieler wechseln
                _aktSpieler = (_aktSpieler == 'X') ? 'O' : 'X';
                _dieGui.ausgabeText($"Spieler {ermittleAktSpieler()} ist am Zug"); // Labels aktualisieren
            }
        }
        
        private void erhoeheAnzZuege()
        {
            _anzahlZuege++;
        }
        
        
        
    }
}
