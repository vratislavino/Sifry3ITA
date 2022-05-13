using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sifry3ITA
{
    public partial class Form1 : Form
    {
        string abeceda = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sifra sifra;
            if(radioButton1.Checked)
            {
                sifra = new TranspozicniSifra(abeceda, (int)numericUpDown1.Value);
            } else
            {
                sifra = new SubstitucniSifra(abeceda, GetKey());
            }

            string sifrovatelnyText = KonvertujText(richTextBox1.Text);
            richTextBox1.Text = sifrovatelnyText;
            string sifrovanyText = sifra.Zasifruj(sifrovatelnyText);
            richTextBox2.Text = sifrovanyText;
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
    }
}
