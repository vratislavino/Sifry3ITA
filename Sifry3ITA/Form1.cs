using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sifry3ITA
{
    public partial class Form1 : Form
    {
        string abeceda = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Dictionary<string, string> substitucniKlic;

        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = abeceda.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sifra sifra = GetCurrentSifra();

            string sifrovatelnyText = KonvertujText(richTextBox1.Text);
            richTextBox1.Text = sifrovatelnyText;
            string sifrovanyText = sifra.Zasifruj(sifrovatelnyText);
            richTextBox2.Text = sifrovanyText;
        }

        private Sifra GetCurrentSifra()
        {
            Sifra sifra;
            if (radioButton1.Checked)
            {
                sifra = new TranspozicniSifra(abeceda, (int)numericUpDown1.Value);
            }
            else
            {
                sifra = new SubstitucniSifra(abeceda, substitucniKlic);
            }
            return sifra;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sifra sifra = GetCurrentSifra();
            string rozsifrovatelnyText = KonvertujText(richTextBox1.Text);
            richTextBox1.Text = rozsifrovatelnyText;
            string rozsifrovanyText = sifra.Rozsifruj(rozsifrovatelnyText);
            richTextBox2.Text = rozsifrovanyText;
        }

        private string KonvertujText(string text)
        {
            return text.ToUpperInvariant()
                .Replace("Č", "C")
                .Replace("Ě", "E")
                .Replace("É", "E")
                .Replace("Ř", "R")
                .Replace("Ť", "T")
                .Replace("Ž", "Z")
                .Replace("Ú", "U")
                .Replace("Ů", "U")
                .Replace("Á", "A")
                .Replace("Š", "S")
                .Replace("Ď", "D")
                .Replace("Ý", "Y")
                .Replace("Í", "I")
                .Replace("Ó", "O")
                .Replace("Ň", "N");
        }

        private string GetKey() { 
            return string.Join("", abeceda.Reverse()); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\vrati\OneDrive\Plocha";
            ofd.Filter = "Textové soubory s abecedou (*.txt)|*.txt";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                LoadAbeceda(ofd.FileName);
            } else
            {
                // pokud dal Storno nebo X
            }
        }

        private void LoadAbeceda(string path) {
            string[] lines = File.ReadAllLines(path);
            Dictionary<string, string> abeceda = new Dictionary<string, string>();

            foreach (string line in lines) { 
                if(line.Length > 1)
                {
                    abeceda.Add(line[0].ToString(), line[1].ToString());
                }
            }

            substitucniKlic = abeceda;
            button1.BackColor = Color.Green;
        }
    }
}
