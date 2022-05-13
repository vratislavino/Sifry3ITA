using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifry3ITA
{
    internal abstract class Sifra
    {
        protected string abeceda;
        public Sifra(string abeceda) {
            this.abeceda = abeceda;
        }

        public abstract string Zasifruj(string text);

        public abstract string Rozsifruj(string text);
    }

    internal class TranspozicniSifra : Sifra
    {
        private int klic;

        public TranspozicniSifra(string abeceda, int posun) : base(abeceda)
        {
            this.klic = posun;
        }

        public override string Rozsifruj(string text)
        {
            throw new NotImplementedException();
        }

        public override string Zasifruj(string text)
        {
            string sifrovany = "";

            for(int i = 0; i < text.Length; i++)
            {
                int index = abeceda.IndexOf(text[i]);
                index += klic;
                index %= abeceda.Length;
                sifrovany += abeceda[index];
            }

            return sifrovany;
        }
    }

    internal class SubstitucniSifra : Sifra
    {
        private string klic;

        public SubstitucniSifra(string abeceda, string klic) : base(abeceda)
        {
            this.klic = klic;
        }

        public override string Rozsifruj(string text)
        {
            throw new NotImplementedException();
        }

        public override string Zasifruj(string text)
        {
            throw new NotImplementedException();
        }
    }
}
