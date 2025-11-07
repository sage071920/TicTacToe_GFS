using System;

namespace TicTacToe_GFS
{
    public class Daten
    {
        private char[,] _spielFeld = new char[3,3];

        public bool setzeFeld(int pNr, char pAktSpieler)
        {
            int zeile = (pNr - 1) / 3;
            int spalte = (pNr - 1) % 3;
            if (_spielFeld[zeile, spalte] == '\0')
            {
                _spielFeld[zeile, spalte] = pAktSpieler;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}