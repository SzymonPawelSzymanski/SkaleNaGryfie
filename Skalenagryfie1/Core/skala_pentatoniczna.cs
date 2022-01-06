using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Content
{
    public class Skala_pentatoniczna
    {
        /// <summary>
        /// Klasa skala pentatoniczna określa budowę skal, na których operujemy grając
        /// </summary>

        public string nazwa_skali = " ";
        public int ilosc_nut = 5;
        const int wiersze = 5;
        const int kolumny = 4;
        public String[] tab_nut = new String[5];
        public int[,] tab_inf = new int[wiersze , kolumny];

        public void wyswietl_skale_pion(String[] tab)
        {
            int i = 0;
            for (i = 0; i < tab.Length; i++)
            {
                Console.WriteLine("Nuta nr " + i + " w skali " + nazwa_skali + " to " + tab_nut[i]);
            }
        }
        public void wyswietl_skale_poziom(String[] tab)
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

        public void wypelnij_inf(int indeks, int lx, int ly, int width, int height)
        {
            tab_inf[indeks-1, 0] = lx;
            tab_inf[indeks-1, 1] = ly;
            tab_inf[indeks-1, 2] = width;
            tab_inf[indeks-1, 3] = height;
        }
    }
}
