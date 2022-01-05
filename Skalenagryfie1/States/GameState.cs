using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Skalenagryfie1.Core;
using Skalenagryfie1.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;



namespace Skalenagryfie1.Content.States
{
    internal class GameState : Component//dziedziczy wszycho po klasie State (astrakcyjnej ktora sluzy tylko do dziedziczenia)
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private double timer = 0;
        private String czas;
        public SpriteFont tytulStrony;
        private MouseState ms, oldMs;
        private Rectangle msRect;
        private Texture2D teksturaGryfu;
        private Texture2D teksturaNuty;
        private Texture2D teksturaBoxa;
        private Texture2D wongamescreen;
        private SpriteFont fontNuty;
        private SpriteFont fontSkali;
        private String nazwaSkali;
        private int los;
        private int los_2;
        private int wynik = 0;
        private int wygrana_gra = 0;
        private bool wygrana_bool;
        //private int zajety_kursor = 0;
        private Random rand = new Random();
        const int INCREMENT = 130;
        const int INCREMENT_N = 70;
        private const int MAX_BTNS = 5;
        private const int MAX_NOTES = 5;
        private const int MAX_SCALES = 12;
        private Texture2D[] btns = new Texture2D[MAX_BTNS];
        private Rectangle[] btnRects = new Rectangle[MAX_BTNS];
        private Texture2D[] nuty = new Texture2D[MAX_NOTES];
        private Rectangle[] nutyRects = new Rectangle[MAX_NOTES];
        private String[] nutyText = new String[MAX_NOTES];
        private String trzymana_nuta = "NIC YET";
        private String kolejnoscnuta = "NIC YET";
        private Color kolornuty = Color.White;
        private Color[] kolNut = new Color[MAX_NOTES];
        private String[] rozwNuty =  new String[MAX_NOTES];
        private bool[] boolNuty = new bool[MAX_NOTES];
        private Rectangle[] interRects = new Rectangle[MAX_NOTES];
        private Skala_pentatoniczna[] molPent = new Skala_pentatoniczna[MAX_SCALES];
        private Skala_pentatoniczna[] durPent = new Skala_pentatoniczna[MAX_SCALES];
        private Skala_pentatoniczna obecna_skala;
        private Rectangle hitboxTest;
        public bool reset;
        /*
         * 1. Ogarnij timer
         * 2. Ogarnij dobre wymiary gryfu do hitboxow
         * 3. Warunki wygrania gry
         * 4. Zliczanie wyniku
         * 5. Zapisywanie wyniku
         * 6. Instrukcja gry ci nie dziala
         */


        internal override void LoadContent(ContentManager Content)
        {
            this._content = Content;
            teksturaGryfu = Content.Load<Texture2D>("Tekstury/rysunek_gryf_1");
            wongamescreen = Content.Load<Texture2D>("Tekstury/wongamescreen");
            teksturaNuty = Content.Load<Texture2D>("Tekstury/tlonutki40");
            teksturaBoxa = Content.Load<Texture2D>("Tekstury/pudelko_nut_2");
            fontNuty = Content.Load<SpriteFont>("Fonts/nutkafont");
            fontSkali = Content.Load<SpriteFont>("Fonts/skalafont");
            hitboxTest = new Rectangle(10, 10, 100, 100);

            #region Stworzenie_pentatonik
            //STWORZENIE PENTATONIK MOLOWYCH
            var e_pent_mol = new Skala_pentatoniczna();
            var f_pent_mol = new Skala_pentatoniczna();
            var fis_pent_mol = new Skala_pentatoniczna();
            var g_pent_mol = new Skala_pentatoniczna();
            var gis_pent_mol = new Skala_pentatoniczna();
            var a_pent_mol = new Skala_pentatoniczna();
            var ais_pent_mol = new Skala_pentatoniczna();
            var h_pent_mol = new Skala_pentatoniczna();
            var c_pent_mol = new Skala_pentatoniczna();
            var cis_pent_mol = new Skala_pentatoniczna();
            var d_pent_mol = new Skala_pentatoniczna();
            var dis_pent_mol = new Skala_pentatoniczna();

            e_pent_mol.nazwa_skali = "Skala E mol Pentatoniczna";
            f_pent_mol.nazwa_skali = "Skala F mol Pentatoniczna";
            fis_pent_mol.nazwa_skali = "Skala Fis mol Pentatoniczna";
            g_pent_mol.nazwa_skali = "Skala G mol Pentatoniczna";
            gis_pent_mol.nazwa_skali = "Skala Gis mol Pentatoniczna";
            a_pent_mol.nazwa_skali = "Skala A mol Pentatoniczna";
            ais_pent_mol.nazwa_skali = "Skala Ais mol Pentatoniczna";
            h_pent_mol.nazwa_skali = "Skala H mol Pentatoniczna";
            c_pent_mol.nazwa_skali = "Skala C mol Pentatoniczna";
            cis_pent_mol.nazwa_skali = "Skala Cis mol Pentatoniczna";
            d_pent_mol.nazwa_skali = "Skala D mol Pentatoniczna";
            dis_pent_mol.nazwa_skali = "Skala Dis mol Pentatoniczna";

            e_pent_mol.wypelnij_skale("E", "G", "A", "H", "D");
            f_pent_mol.wypelnij_skale("F", "Gis", "Ais", "C", "Dis");
            fis_pent_mol.wypelnij_skale("Fis", "A", "H", "Cis", "E");
            g_pent_mol.wypelnij_skale("G", "Ais", "C", "D", "F");
            gis_pent_mol.wypelnij_skale("Gis", "B", "Cis", "Dis", "Fis");
            a_pent_mol.wypelnij_skale("A", "C", "D", "E", "G");
            ais_pent_mol.wypelnij_skale("Ais", "Cis", "Dis", "F", "Gis");
            h_pent_mol.wypelnij_skale("H", "D", "E", "Fis", "A");
            c_pent_mol.wypelnij_skale("C", "Dis", "F", "G", "Ais");
            cis_pent_mol.wypelnij_skale("Cis", "E", "Fis", "Gis", "H");
            d_pent_mol.wypelnij_skale("D", "F", "G", "A", "C");
            dis_pent_mol.wypelnij_skale("Dis", "Fis", "Gis", "Ais", "Cis");

            //STWORZENIE PENTATONIK DUROWYCH
            var e_pent_dur = new Skala_pentatoniczna();
            var f_pent_dur = new Skala_pentatoniczna();
            var fis_pent_dur = new Skala_pentatoniczna();
            var g_pent_dur = new Skala_pentatoniczna();
            var gis_pent_dur = new Skala_pentatoniczna();
            var a_pent_dur = new Skala_pentatoniczna();
            var ais_pent_dur = new Skala_pentatoniczna();
            var h_pent_dur = new Skala_pentatoniczna();
            var c_pent_dur = new Skala_pentatoniczna();
            var cis_pent_dur = new Skala_pentatoniczna();
            var d_pent_dur = new Skala_pentatoniczna();
            Skala_pentatoniczna dis_pent_dur = new Skala_pentatoniczna();

            e_pent_dur.nazwa_skali = "Skala E dur Pentatoniczna";
            f_pent_dur.nazwa_skali = "Skala F dur Pentatoniczna";
            fis_pent_dur.nazwa_skali = "Skala Fis dur Pentatoniczna";
            g_pent_dur.nazwa_skali = "Skala G dur Pentatoniczna";
            gis_pent_dur.nazwa_skali = "Skala Gis dur Pentatoniczna";
            a_pent_dur.nazwa_skali = "Skala A dur Pentatoniczna";
            ais_pent_dur.nazwa_skali = "Skala Ais dur Pentatoniczna";
            h_pent_dur.nazwa_skali = "Skala H dur Pentatoniczna";
            c_pent_dur.nazwa_skali = "Skala C dur Pentatoniczna";
            cis_pent_dur.nazwa_skali = "Skala Cis dur Pentatoniczna";
            d_pent_dur.nazwa_skali = "Skala D dur Pentatoniczna";
            dis_pent_dur.nazwa_skali = "Skala Dis dur Pentatoniczna";
            //dis_pent_dur.nazwa_skali = "Skala Dis dur Pentatoniczna";


            e_pent_dur.wypelnij_skale("E", "Fis", "Gis", "H", "Cis");
            f_pent_dur.wypelnij_skale("F", "G", "A", "C", "D");
            fis_pent_dur.wypelnij_skale("Fis", "Gis", "Ais", "Cis", "Dis");
            g_pent_dur.wypelnij_skale("G", "A", "H", "D", "E");
            gis_pent_dur.wypelnij_skale("Gis", "Ais", "C", "Dis", "F");
            a_pent_dur.wypelnij_skale("A", "H", "Cis", "E", "Fis");
            ais_pent_dur.wypelnij_skale("Ais", "C", "D", "F", "G");
            h_pent_dur.wypelnij_skale("H", "Cis", "Dis", "Fis", "Gis");
            c_pent_dur.wypelnij_skale("C", "D", "E", "G", "A");
            cis_pent_dur.wypelnij_skale("Cis", "Dis", "F", "Gis", "Ais");
            d_pent_dur.wypelnij_skale("D", "E", "Fis", "A", "H");
            dis_pent_dur.wypelnij_skale("Dis", "F", "G", "Ais", "C");
            #endregion

            #region wypelnienie tablicy skal
            molPent[0] = e_pent_mol;
            molPent[1] = f_pent_mol;
            molPent[2] = fis_pent_mol;
            molPent[3] = g_pent_mol;
            molPent[4] = gis_pent_mol;
            molPent[5] = a_pent_mol;
            molPent[6] = ais_pent_mol;
            molPent[7] = h_pent_mol;
            molPent[8] = c_pent_mol;
            molPent[9] = cis_pent_mol;
            molPent[10] = d_pent_mol;
            molPent[11] = dis_pent_mol;

            durPent[0] = e_pent_dur;
            durPent[1] = f_pent_dur;
            durPent[2] = fis_pent_dur;
            durPent[3] = g_pent_dur;
            durPent[4] = gis_pent_dur;
            durPent[5] = a_pent_dur;
            durPent[6] = ais_pent_dur;
            durPent[7] = h_pent_dur;
            durPent[8] = c_pent_dur;
            durPent[9] = cis_pent_dur;
            durPent[10] = d_pent_dur;
            durPent[11] = dis_pent_dur;
            #endregion

            #region Wypelnienie wspolrzednych i rozmiarow hitboxow - MOL

            e_pent_mol.wypelnij_inf(1, 21, 514, 48, 38); 
            e_pent_mol.wypelnij_inf(2, 266, 514, 103, 45);
            e_pent_mol.wypelnij_inf(3, 21, 459, 48, 54);
            e_pent_mol.wypelnij_inf(4, 162, 461, 103, 53);
            e_pent_mol.wypelnij_inf(5, 21, 409, 48, 51);//

            f_pent_mol.wypelnij_inf(1, 70, 514, 91, 40);
            f_pent_mol.wypelnij_inf(2, 370, 516, 93, 46);
            f_pent_mol.wypelnij_inf(3, 70, 459, 91, 55);
            f_pent_mol.wypelnij_inf(4, 266, 458, 103, 56);
            f_pent_mol.wypelnij_inf(5, 70, 409, 91, 51);//

            fis_pent_mol.wypelnij_inf(1, 162, 514, 103, 42);
            fis_pent_mol.wypelnij_inf(2, 464, 519, 89, 46);
            fis_pent_mol.wypelnij_inf(3, 162, 461, 103, 53);
            fis_pent_mol.wypelnij_inf(4, 370, 459, 93, 57);
            fis_pent_mol.wypelnij_inf(5, 162, 407, 103, 54);//

            g_pent_mol.wypelnij_inf(1, 266, 514, 103, 45);
            g_pent_mol.wypelnij_inf(2, 554, 520, 85, 49);
            g_pent_mol.wypelnij_inf(3, 266, 458, 103, 56);
            g_pent_mol.wypelnij_inf(4, 464, 459, 89, 59);
            g_pent_mol.wypelnij_inf(5, 266, 405, 103, 52);//

            gis_pent_mol.wypelnij_inf(1, 370, 516, 93, 46);
            gis_pent_mol.wypelnij_inf(2, 640, 521, 80, 50);
            gis_pent_mol.wypelnij_inf(3, 370, 459, 93, 57);
            gis_pent_mol.wypelnij_inf(4, 554, 459, 85, 61);
            gis_pent_mol.wypelnij_inf(5, 370, 402, 93, 56);//

            a_pent_mol.wypelnij_inf(1, 464, 519, 89, 46);
            a_pent_mol.wypelnij_inf(2, 721, 521, 72, 50);
            a_pent_mol.wypelnij_inf(3, 464, 459, 89, 59);
            a_pent_mol.wypelnij_inf(4, 640, 460, 80, 61);
            a_pent_mol.wypelnij_inf(5, 464, 402, 89, 56);//

            ais_pent_mol.wypelnij_inf(1, 554, 520, 85, 49);
            ais_pent_mol.wypelnij_inf(2, 794, 524, 73, 51);
            ais_pent_mol.wypelnij_inf(3, 554, 459, 85, 61);
            ais_pent_mol.wypelnij_inf(4, 721, 458, 72, 66);
            ais_pent_mol.wypelnij_inf(5, 554, 402, 85, 56);//

            h_pent_mol.wypelnij_inf(1, 640, 521, 80, 50);
            h_pent_mol.wypelnij_inf(2, 868, 524, 65, 51);
            h_pent_mol.wypelnij_inf(3, 640, 460, 80, 61);
            h_pent_mol.wypelnij_inf(4, 794, 458, 73, 66);
            h_pent_mol.wypelnij_inf(5, 640, 409, 80, 51);// 

            c_pent_mol.wypelnij_inf(1, 721, 521, 72, 50);
            c_pent_mol.wypelnij_inf(2, 934, 524, 63, 53);
            c_pent_mol.wypelnij_inf(3, 721, 458, 72, 66);
            c_pent_mol.wypelnij_inf(4, 868, 458, 65, 66);
            c_pent_mol.wypelnij_inf(5, 721, 396, 72, 62);//

            cis_pent_mol.wypelnij_inf(1, 794, 524, 73, 51);
            cis_pent_mol.wypelnij_inf(2, 998, 527, 61, 53);
            cis_pent_mol.wypelnij_inf(3, 794, 458, 73, 66);
            cis_pent_mol.wypelnij_inf(4, 934, 457, 63, 70);
            cis_pent_mol.wypelnij_inf(5, 794, 396, 73, 62);//

            d_pent_mol.wypelnij_inf(1, 868, 524, 65, 51);
            d_pent_mol.wypelnij_inf(2, 1060, 527, 56, 55);
            d_pent_mol.wypelnij_inf(3, 868, 458, 65, 66);
            d_pent_mol.wypelnij_inf(4, 998, 457, 61, 70);
            d_pent_mol.wypelnij_inf(5, 868, 393, 65, 65);//

            dis_pent_mol.wypelnij_inf(1, 934, 524, 63, 53);
            dis_pent_mol.wypelnij_inf(2, 117, 527, 52, 57);
            dis_pent_mol.wypelnij_inf(3, 934, 457, 63, 70);
            dis_pent_mol.wypelnij_inf(4, 1060, 457, 56, 70);
            dis_pent_mol.wypelnij_inf(5, 934, 386, 63, 72);//

            #endregion

            #region Wypelnienie wspolrzednych i rozmiarow hitboxow - DUR

            e_pent_dur.wypelnij_inf(1, 21, 514, 48, 38);
            e_pent_dur.wypelnij_inf(2, 162, 514, 103, 42);
            e_pent_dur.wypelnij_inf(3, 370, 516, 93, 46);
            e_pent_dur.wypelnij_inf(4, 162, 461, 103, 53);
            e_pent_dur.wypelnij_inf(5, 370, 459, 93, 57);//

            f_pent_dur.wypelnij_inf(1, 70, 514, 91, 40);
            f_pent_dur.wypelnij_inf(2, 266, 514, 103, 45);
            f_pent_dur.wypelnij_inf(3, 464, 519, 89, 46);
            f_pent_dur.wypelnij_inf(4, 266, 458, 103, 56);
            f_pent_dur.wypelnij_inf(5, 464, 459, 89, 59);//

            fis_pent_dur.wypelnij_inf(1, 162, 514, 103, 42);
            fis_pent_dur.wypelnij_inf(2, 370, 516, 93, 46);
            fis_pent_dur.wypelnij_inf(3, 554, 520, 85, 49);
            fis_pent_dur.wypelnij_inf(4, 370, 459, 93, 57);
            fis_pent_dur.wypelnij_inf(5, 554, 459, 85, 61);//

            g_pent_dur.wypelnij_inf(1, 266, 514, 103, 45);
            g_pent_dur.wypelnij_inf(2, 464, 519, 89, 46);
            g_pent_dur.wypelnij_inf(3, 640, 521, 80, 50);
            g_pent_dur.wypelnij_inf(4, 464, 459, 89, 59);
            g_pent_dur.wypelnij_inf(5, 640, 460, 80, 61);//

            gis_pent_dur.wypelnij_inf(1, 370, 516, 93, 46);
            gis_pent_dur.wypelnij_inf(2, 554, 520, 85, 49);
            gis_pent_dur.wypelnij_inf(3, 721, 521, 72, 50);
            gis_pent_dur.wypelnij_inf(4, 554, 459, 85, 61);
            gis_pent_dur.wypelnij_inf(5, 721, 458, 72, 66);//

            a_pent_dur.wypelnij_inf(1, 464, 519, 89, 46);
            a_pent_dur.wypelnij_inf(2, 640, 521, 80, 50);
            a_pent_dur.wypelnij_inf(3, 794, 524, 73, 51);
            a_pent_dur.wypelnij_inf(4, 640, 460, 80, 61);
            a_pent_dur.wypelnij_inf(5, 794, 458, 73, 66);//

            ais_pent_dur.wypelnij_inf(1, 554, 520, 85, 49);
            ais_pent_dur.wypelnij_inf(2, 721, 521, 72, 50);
            ais_pent_dur.wypelnij_inf(3, 868, 524, 65, 51);
            ais_pent_dur.wypelnij_inf(4, 721, 458, 72, 66);
            ais_pent_dur.wypelnij_inf(5, 868, 458, 65, 66);//

            h_pent_dur.wypelnij_inf(1, 640, 521, 80, 50);
            h_pent_dur.wypelnij_inf(2, 794, 524, 73, 51);
            h_pent_dur.wypelnij_inf(3, 934, 524, 63, 53);
            h_pent_dur.wypelnij_inf(4, 794, 458, 73, 66);
            h_pent_dur.wypelnij_inf(5, 934, 457, 63, 70);//

            c_pent_dur.wypelnij_inf(1, 721, 521, 72, 50);
            c_pent_dur.wypelnij_inf(2, 868, 524, 65, 51);
            c_pent_dur.wypelnij_inf(3, 998, 527, 61, 53);
            c_pent_dur.wypelnij_inf(4, 868, 458, 65, 66);
            c_pent_dur.wypelnij_inf(5, 998, 457, 61, 70);//

            cis_pent_dur.wypelnij_inf(1, 794, 524, 73, 51);
            cis_pent_dur.wypelnij_inf(2, 934, 524, 63, 53);
            cis_pent_dur.wypelnij_inf(3, 1060, 527, 56, 55);
            cis_pent_dur.wypelnij_inf(4, 934, 457, 63, 70);
            cis_pent_dur.wypelnij_inf(5, 1060, 457, 56, 70);//

            d_pent_dur.wypelnij_inf(1, 868, 524, 65, 51);
            d_pent_dur.wypelnij_inf(2, 998, 527, 61, 53);
            d_pent_dur.wypelnij_inf(3, 1117, 527, 52, 57);
            d_pent_dur.wypelnij_inf(4, 998, 457, 61, 70);
            d_pent_dur.wypelnij_inf(5, 1117, 457, 52, 70);//

            dis_pent_dur.wypelnij_inf(1, 934, 524, 63, 53);
            dis_pent_dur.wypelnij_inf(2, 1060, 527, 56, 55);
            dis_pent_dur.wypelnij_inf(3, 1170, 527, 53, 59);
            dis_pent_dur.wypelnij_inf(4, 1060, 457, 56, 70);
            dis_pent_dur.wypelnij_inf(5, 1170, 457, 53, 70);//
            #endregion

            #region Wypelnienie kolorow nut
            kolNut[0] = Color.White;
            kolNut[1] = Color.White;
            kolNut[2] = Color.White;
            kolNut[3] = Color.White;
            kolNut[4] = Color.White;
            #endregion

            los = rand.Next(2);
            los_2 = rand.Next(12);

            //los = 0;
            //los_2 = 0;



            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = Content.Load<Texture2D>($"Tekstury/btn{i + 1}");
                btnRects[i] = new Rectangle(1060, 600 + INCREMENT * i, btns[i].Width, btns[i].Height);
            }

            if (los == 0)
            {
                obecna_skala = molPent[los_2];
                nazwaSkali = molPent[los_2].nazwa_skali;
                for (int i = 0; i < nuty.Length; i++)
                {
                    nuty[i] = Content.Load<Texture2D>("Tekstury/tlonutki40");
                    nutyRects[i] = new Rectangle(120 + INCREMENT_N * i, 800, nuty[i].Width, nuty[i].Height);
                    nutyText[i] = molPent[los_2].tab_nut[i];
                }
            }
            else if (los == 1)
            {
                obecna_skala = durPent[los_2];
                nazwaSkali = durPent[los_2].nazwa_skali;
                for (int i = 0; i < nuty.Length; i++)
                {
                    nuty[i] = Content.Load<Texture2D>("Tekstury/tlonutki40");
                    nutyRects[i] = new Rectangle(120 + INCREMENT_N * i, 800, nuty[i].Width, nuty[i].Height);
                    nutyText[i] = durPent[los_2].tab_nut[i];
                }
            }

            #region Wczytanie wspolrzednych hitboxow

            for (int i = 0; i < 5; i++)
            {
                interRects[i] = new Rectangle(obecna_skala.tab_inf[i, 0], obecna_skala.tab_inf[i, 1], obecna_skala.tab_inf[i, 2], obecna_skala.tab_inf[i, 3]);
            }

            #endregion

        }

        public override void Update(GameTime gameTime)
        {
            if (wygrana_bool == false) {timer += gameTime.ElapsedGameTime.TotalSeconds; }
            czas = Math.Ceiling(timer).ToString();
            oldMs = ms;
            ms = Mouse.GetState();
            msRect = new Rectangle(ms.X, ms.Y, 1, 1);
            if (reset == true)
            {
                GameStateManager.gs = new GameState();
                GameStateManager.gs.LoadContent(_content);
                //GameStateManager.reset_game = true;
                reset = false;
            }
            //wynik -= (int)(Math.Ceiling(timer)/60);

            //if (ms.LeftButton == ButtonState.Pressed)
            //{
            //    zajety_kursor = 1;
            //}
            //else
            //{
            //    zajety_kursor = 0;
            //}

            if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(new Rectangle(530 - btnRects[3].Width / 2, 805, btnRects[3].Width, btnRects[3].Height - 20)) && wygrana_gra ==5)
            {
                reset = true;
                Data.CurrentState = Data.States.Game;
            }

            else if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(new Rectangle(750 - btnRects[4].Width / 2, 805, btnRects[4].Width, btnRects[4].Height - 20)) && wygrana_gra == 5)
            {
                Data.Exit = true; ;
            }

            else if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRects[2]))
            {
                reset = true;
                Data.CurrentState = Data.States.Menu;
            }

            for (int i = 0; i < nuty.Length; i++)
            {
                kolejnoscnuta = nutyText[i];
                if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(nutyRects[i]) && trzymana_nuta != rozwNuty[i])
                {
                    if (rozwNuty[i] != nutyText[i])
                    {
                        kolNut[i] = Color.White;
                        trzymana_nuta = nutyText[i];
                        nutyRects[i].X = ms.X - (nutyRects[i].Width / 2);
                        nutyRects[i].Y = ms.Y - (nutyRects[i].Height / 2);
                    }
                }
                else
                {
                }

                
                    if (ms.LeftButton == ButtonState.Released && nutyRects[i].Intersects(interRects[i]) && trzymana_nuta == nutyText[i] && trzymana_nuta != rozwNuty[i])
                    {
                            if (rozwNuty[i] != nutyText[i])
                            {
                                if (boolNuty[i] == false) 
                                    {   wynik += 100; 
                                        wygrana_gra += 1;}

                                    rozwNuty[i] = nutyText[i];
                                    boolNuty[i] = true;
                                    kolNut[i] = Color.LimeGreen;
                                    nutyRects[i].X = interRects[i].X + interRects[i].Width / 2 - nutyRects[i].Width / 2;
                                    nutyRects[i].Y = interRects[i].Y + interRects[i].Height / 2 - nutyRects[i].Height / 2;
                            }    
                    }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(teksturaGryfu, new Rectangle(35, 150, teksturaGryfu.Width, teksturaGryfu.Height), Color.White);
            spriteBatch.Draw(teksturaBoxa, new Rectangle(35, 550, teksturaBoxa.Width, teksturaBoxa.Height), Color.White);
            spriteBatch.Draw(btns[4], btnRects[2], Color.White);
            //spriteBatch.Draw(btns[2], btnRects[2], Color.White);
            //spriteBatch.DrawString(fontSkali,"Uzupelnij: ", new Vector2(430,100), Color.White);
            spriteBatch.DrawString(fontSkali, nazwaSkali, new Vector2(400,100), Color.White);
            spriteBatch.DrawString(fontSkali, "pozycja #1", new Vector2(550,140), Color.White);
            //spriteBatch.DrawString(fontSkali, trzymana_nuta, new Vector2(400, 200), Color.White);
            spriteBatch.DrawString(fontSkali, "Czas gry: " + czas + "s", new Vector2(1000, 140), Color.White);
            spriteBatch.DrawString(fontSkali, "Wynik: " + wynik, new Vector2(1000, 100), Color.White);
            //spriteBatch.DrawString(fontSkali, "Zajety kursor: " + zajety_kursor.ToString(), new Vector2(1000, 300), Color.White);
            //spriteBatch.DrawString(fontSkali, czas.ToString(), new Vector2(400, 200), Color.White);
            //spriteBatch.Draw(teksturaGryfu, hitboxTest, Color.White);

               
            

            if (msRect.Intersects(btnRects[2]))
            {
                spriteBatch.Draw(btns[4], btnRects[2], Color.Gray);
            }

            for (int i = 0; i < nuty.Length; i++)
            {
                spriteBatch.Draw(nuty[i], nutyRects[i], kolNut[i]);
                spriteBatch.DrawString(fontNuty, nutyText[i], new Vector2(nutyRects[i].X + nuty[i].Width/4, nutyRects[i].Y + nuty[i].Height/5), Color.White);

                if (msRect.Intersects(nutyRects[i]))
                {
                    spriteBatch.Draw(nuty[i], nutyRects[i], Color.Gray);
                    spriteBatch.DrawString(fontNuty, nutyText[i], new Vector2(nutyRects[i].X + nuty[i].Width/4, nutyRects[i].Y + nuty[i].Height/5), Color.Gray);
                }
            }

          
            if (wygrana_gra == 5)
            {
                int increment_3 = 52;
                wygrana_bool = true;
                spriteBatch.Draw(wongamescreen, new Rectangle(240, 100, wongamescreen.Width, wongamescreen.Height), Color.White);
                spriteBatch.DrawString(fontSkali, nazwaSkali, new Vector2(430, 250), Color.White);
                spriteBatch.DrawString(fontSkali, wynik.ToString() + " pkt", new Vector2(643, 372), Color.White);
                spriteBatch.DrawString(fontSkali, czas.ToString() + "s", new Vector2(620, 425), Color.White);
                spriteBatch.DrawString(fontSkali, nutyText[0], new Vector2(640, 527 + increment_3*0), Color.White);
                spriteBatch.DrawString(fontSkali, nutyText[1], new Vector2(640, 525 + increment_3*1), Color.White);
                spriteBatch.DrawString(fontSkali, nutyText[2], new Vector2(640, 524 + increment_3*2), Color.White);
                spriteBatch.DrawString(fontSkali, nutyText[3], new Vector2(640, 524 + increment_3*3), Color.White);
                spriteBatch.DrawString(fontSkali, nutyText[4], new Vector2(640, 521 + increment_3*4), Color.White);
                spriteBatch.Draw(btns[3], new Rectangle(530 - btnRects[3].Width/2, 805, btnRects[3].Width, btnRects[3].Height-20), Color.White);
                spriteBatch.Draw(btns[2], new Rectangle(750 - btnRects[4].Width/2, 805, btnRects[4].Width, btnRects[4].Height-20), Color.White);
                if (msRect.Intersects(new Rectangle(530 - btnRects[3].Width / 2, 805, btnRects[3].Width, btnRects[3].Height-20)))
                {
                    spriteBatch.Draw(btns[3], new Rectangle(530 - btnRects[3].Width / 2, 805, btnRects[3].Width, btnRects[3].Height-20), Color.Gray);

                }
                else if (msRect.Intersects(new Rectangle(750 - btnRects[4].Width / 2, 805, btnRects[4].Width, btnRects[4].Height - 20)))
                {
                    spriteBatch.Draw(btns[2], new Rectangle(750 - btnRects[4].Width / 2, 805, btnRects[4].Width, btnRects[4].Height - 20), Color.Gray);
                }
            }
        }
    }
}