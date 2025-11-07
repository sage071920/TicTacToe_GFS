using System;
using System.Windows.Forms;

public class Oberflaeche : Form
{
    private Steuerung dieSteuerung;
    private Button[] felder = new Button[9];
    private Label lblStatus;
    private Label lblStatistik;
    private Button btnNeuesSpiel;

    public Oberflaeche(Steuerung pSteuerung)
    {
        dieSteuerung = pSteuerung;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "Tic Tac Toe";
        this.Size = new System.Drawing.Size(400, 500);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        // Spielfeld (3x3 Buttons)
        for (int i = 0; i < 9; i++)
        {
            int nr = i + 1;
            felder[i] = new Button
            {
                Size = new System.Drawing.Size(80, 80),
                Location = new System.Drawing.Point(50 + (i % 3) * 90, 50 + (i / 3) * 90),
                Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold),
                Tag = nr
            };
            felder[i].Click += Feld_Click;
            this.Controls.Add(felder[i]);
        }

        // Statuslabel
        lblStatus = new Label
        {
            Location = new System.Drawing.Point(50, 330),
            Size = new System.Drawing.Size(300, 30),
            Text = "Spieler X beginnt."
        };
        this.Controls.Add(lblStatus);

        // Statistik
        lblStatistik = new Label
        {
            Location = new System.Drawing.Point(50, 370),
            Size = new System.Drawing.Size(300, 50),
            Text = "Spieler X gewonnen: 0\nSpieler O gewonnen: 0"
        };
        this.Controls.Add(lblStatistik);

        // Neues Spiel Button
        btnNeuesSpiel = new Button
        {
            Text = "Neues Spiel",
            Location = new System.Drawing.Point(50, 430),
            Size = new System.Drawing.Size(100, 40)
        };
        btnNeuesSpiel.Click += (s, e) => dieSteuerung.bearbeiteTaste('N');
        this.Controls.Add(btnNeuesSpiel);

        // Tastatur: N für Neues Spiel
        this.KeyPreview = true;
        this.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.N)
                dieSteuerung.bearbeiteTaste('N');
        };
    }

    private void Feld_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int nr = (int)btn.Tag;
        dieSteuerung.bearbeiteClick(nr);
    }

    public void markiere(int pNr, char pAktSpieler)
    {
        felder[pNr - 1].Text = pAktSpieler.ToString();
        felder[pNr - 1].Enabled = false;
    }

    public void ausgebenText(string pText)
    {
        lblStatus.Text = pText;
    }

    public void mausClick(int pNr)
    {
        dieSteuerung.bearbeiteClick(pNr);
    }

    public void tastenDruck(char pTaste)
    {
        dieSteuerung.bearbeiteTaste(pTaste);
    }

    public void clearFelder()
    {
        foreach (Button btn in felder)
        {
            btn.Text = "";
            btn.Enabled = true;
        }
    }

    public void updateStatistik(int x, int o)
    {
        lblStatistik.Text = $"Spieler X gewonnen: {x}\nSpieler O gewonnen: {o}";
    }
}