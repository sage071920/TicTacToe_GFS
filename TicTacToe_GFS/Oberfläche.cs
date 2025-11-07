using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace TicTacToe_GFS
{
    public class Oberfläche : Form
    {
        private Steuerung _steuerung; // Variable für die Assoziation

        public Oberfläche(Steuerung pSteuerung)
        {
            _steuerung = pSteuerung; // Speichere die übergebene Steuerung
            this.KeyPreview = true; // Ermöglicht Tastatur-Events für das Form
            this.KeyDown += Oberflaeche_KeyDown; // Tastatur-Event hinzufügen
        }
        
        
        private void ErstelleCellButtons()
        {
            int startX = 38;
            int startY = 48;
            int spacing = 90;
            int index = 1;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button btn = new Button
                    {
                        Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold),
                        Location = new Point(startX + col * spacing, startY + row * spacing),
                        Name = $"btnCell{index}",
                        Size = new Size(80, 80),
                        TabIndex = index + 1,
                        // Text = index.ToString(), // Indexnummer anzeigen
                        UseVisualStyleBackColor = true,
                        Text = $"{index}"
                    };

                    btn.Click += TastenDruck; // Event-Handler zuweisen
                    this.Controls.Add(btn);
                    index++;
                }
            }
        }
        
        
        // Event-Handler für Button-Clicks (Maus, nur für 'X')
        private void TastenDruck(object sender, EventArgs e)
        {
            if (_steuerung.ermittleAktSpieler() == 'X' && sender is Button btn)
            {
                if (int.TryParse(btn.Name.Replace("btnCell", ""), out int nr))
                {
                    _steuerung.bearbeiteClick(nr);
                }
            }
        }
        
        private void Oberflaeche_KeyDown(object sender, KeyEventArgs e)
        {
            if (_steuerung.ermittleAktSpieler() == 'O') // Nur für Spieler 'O'
            {
                int nr = -1;
                switch (e.KeyCode)
                {
                    case Keys.D1:
                    case Keys.NumPad1:
                        nr = 1;
                        break;
                    case Keys.D2:
                    case Keys.NumPad2:
                        nr = 2;
                        break;
                    case Keys.D3:
                    case Keys.NumPad3:
                        nr = 3;
                        break;
                    case Keys.D4:
                    case Keys.NumPad4:
                        nr = 4;
                        break;
                    case Keys.D5:
                    case Keys.NumPad5:
                        nr = 5;
                        break;
                    case Keys.D6:
                    case Keys.NumPad6:
                        nr = 6;
                        break;
                    case Keys.D7:
                    case Keys.NumPad7:
                        nr = 7;
                        break;
                    case Keys.D8:
                    case Keys.NumPad8:
                        nr = 8;
                        break;
                    case Keys.D9:
                    case Keys.NumPad9:
                        nr = 9;
                        break;
                }
                if (nr != -1)
                {
                    e.SuppressKeyPress = true; // Unterdrücke Standardverhalten
                    _steuerung.bearbeiteTaste(nr);
                }
            }
        }
        

        
        public void markiere(int pNr, char pAktSpieler)
        {
            Button btn = this.Controls.Find($"btnCell{pNr}", true).FirstOrDefault() as Button;
            if (btn != null)
            {
                btn.Text = pAktSpieler.ToString();
            }
        }
        
        
        public void InitOberfläche()
        {
            ErstelleCellButtons();
        }

    }
}