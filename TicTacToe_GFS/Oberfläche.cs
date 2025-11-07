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
            InitOberfläche(); // Initialisierung aufrufen

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
                        Text = "", // Initial leer statt index.ToString()
                        UseVisualStyleBackColor = true
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
                    MessageBox.Show($"Click auf Feld {nr}"); // Debug-Message
                    _steuerung.bearbeiteClick(nr);
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