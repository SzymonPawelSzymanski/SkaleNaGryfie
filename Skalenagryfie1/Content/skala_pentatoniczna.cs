using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Content
{
    public class Skala_pentatoniczna
    {
        //DUR - MAJOR ----- MOL - MINOR
        public string nazwa_skali = " ";
        public int ilosc_nut = 5;
        public string[] tab_nut = new string[5];

        public void wyswietl_skale_pion(string[] tab)
        {
            int i = 0;
            for (i = 0; i < tab.Length; i++)
            {
                Console.WriteLine("Nuta nr " + i + " w skali " + nazwa_skali + " to " + tab_nut[i]);
            }
        }
        public void wyswietl_skale_poziom(string[] tab)
        {
            Console.WriteLine("Nuty w skali " + nazwa_skali + " to " + tab_nut[0] + " " + tab_nut[1] + " " + tab_nut[2] + " " + tab_nut[3] + " " + tab_nut[4] + ".");
        }
        public void wypelnij_skale(string pryma, string tercja, string kwarta, string kwinta, string septyma)
        {
            tab_nut[0] = pryma;
            tab_nut[1] = tercja;
            tab_nut[2] = kwarta;
            tab_nut[3] = kwinta;
            tab_nut[4] = septyma;
        }
    }
}
