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
            string rozsifrovany = "";
            for(int i = 0; i < text.Length; i++)
            {
                int index = abeceda.IndexOf(text[i]);
                if(index < 0)
                {
                    rozsifrovany += text[i];
                    continue;
                }

                index -= klic;
                if (index < 0)
                    index += abeceda.Length;
                rozsifrovany += abeceda[index];

            }



            return rozsifrovany;
        }

        public override string Zasifruj(string text)
        {
            string sifrovany = "";

            for(int i = 0; i < text.Length; i++)
            {
                int index = abeceda.IndexOf(text[i]);
                if(index == -1)
                {
                    sifrovany += text[i];
                    continue;
                }
                    
                index += klic;
                index %= abeceda.Length;
                sifrovany += abeceda[index];
            }

            return sifrovany;
        }
    }

    internal class SubstitucniSifra : Sifra
    {
        private Dictionary<string, string> klic;

        public SubstitucniSifra(string abeceda, Dictionary<string, string> klic) : base(abeceda)
        {
            this.klic = klic;
        }

        public override string Rozsifruj(string text)
        {
            string rozsifrovany = "";
            for (int i = 0; i < text.Length; i++)
            {
                if(klic.ContainsValue(text[i].ToString()))
                {
                    rozsifrovany += klic.FirstOrDefault(x => x.Value == text[i].ToString()).Key;
                } else
                {
                    rozsifrovany += text[i].ToString();
                }
            }
            return rozsifrovany;
        }

        public override string Zasifruj(string text)
        {
            string zasifrovany = "";
            for(int i = 0; i < text.Length; i++)
            {
                if(klic.ContainsKey(text[i].ToString()))
                {
                    zasifrovany += klic[text[i].ToString()];
                } else
                {
                    zasifrovany += text[i].ToString();
                }
            }

            return zasifrovany;
        }
    }
}
