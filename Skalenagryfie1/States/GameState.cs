using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Skalenagryfie1.Core;
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
        private static System.Timers.Timer aTimer;
        private DateTime czas;
        public SpriteFont tytulStrony;
        private MouseState ms, oldMs;
        private Rectangle msRect;
        private Texture2D teksturaGryfu;
        private Texture2D teksturaNuty;
        private SpriteFont fontNuty;
        private SpriteFont fontSkali;
        private String nazwaSkali;
        private int los;
        private int los_2;
        private Random rand = new Random();
        private const int MAX_BTNS = 3;
        private const int MAX_NOTES = 5;
        private const int MAX_SCALES = 12;
        private Texture2D[] btns = new Texture2D[MAX_BTNS];
        private Rectangle[] btnRects = new Rectangle[MAX_BTNS];
        private Texture2D[] nuty = new Texture2D[MAX_NOTES];
        private Rectangle[] nutyRects = new Rectangle[MAX_NOTES];
        private String[] nutyText = new String[MAX_NOTES];
        private Skala_pentatoniczna[] molPent = new Skala_pentatoniczna[MAX_SCALES];
        private Skala_pentatoniczna[] durPent = new Skala_pentatoniczna[MAX_SCALES];
        private Rectangle hitboxTest;
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
            aTimer = new System.Timers.Timer(1);
            aTimer.Start();


            teksturaGryfu = Content.Load<Texture2D>("Tekstury/gryfBasowy1000");
            teksturaNuty = Content.Load<Texture2D>("Tekstury/tlonutki30");
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

            los = rand.Next(2);
            los_2 = rand.Next(12);


            const int INCREMENT = 130;
            const int INCREMENT_N = 70;
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = Content.Load<Texture2D>($"Tekstury/btn{i + 1}");
                btnRects[i] = new Rectangle(1060, 300 + INCREMENT * i, btns[i].Width, btns[i].Height);
            }

            if (los == 0)
            {
                nazwaSkali = molPent[los_2].nazwa_skali;
                for (int i = 0; i < nuty.Length; i++)
                {
                    nuty[i] = Content.Load<Texture2D>("Tekstury/tlonutki25");
                    nutyRects[i] = new Rectangle(160 + INCREMENT_N * i, 500, nuty[i].Width, nuty[i].Height);
                    nutyText[i] = molPent[los_2].tab_nut[i];
                }
            }
            else if (los == 1)
            {
                nazwaSkali = durPent[los_2].nazwa_skali;
                for (int i = 0; i < nuty.Length; i++)
                {
                    nuty[i] = Content.Load<Texture2D>("Tekstury/tlonutki25");
                    nutyRects[i] = new Rectangle(160 + INCREMENT_N * i, 500, nuty[i].Width, nuty[i].Height);
                    nutyText[i] = durPent[los_2].tab_nut[i];
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            czas = DateTime.Now;
            oldMs = ms;
            ms = Mouse.GetState();
            msRect = new Rectangle(ms.X, ms.Y, 1, 1);

            if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRects[0]))
            {
                Data.CurrentState = Data.States.Game;
            }
            else if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRects[1]))
            {
                Data.CurrentState = Data.States.Howto2;
            }
            else if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRects[2]))
            {
                Data.Exit = true; ;
            }

            for (int i = 0; i < nuty.Length; i++)
            {
                if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(nutyRects[i]))
                {
                    nutyRects[i].X = ms.X - (nutyRects[i].Width / 2);
                    nutyRects[i].Y = ms.Y - (nutyRects[i].Height / 2);
                }

                if (ms.LeftButton == ButtonState.Released && nutyRects[i].Intersects(hitboxTest))
                {
                    nutyRects[i].X = hitboxTest.X + hitboxTest.Width / 2 - nutyRects[i].Width / 2;
                    nutyRects[i].Y = hitboxTest.Y + hitboxTest.Height / 2 - nutyRects[i].Height / 2;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(teksturaGryfu, new Rectangle(100, 300, teksturaGryfu.Width, teksturaGryfu.Height), Color.White);
            spriteBatch.Draw(btns[2], btnRects[2], Color.White);
            spriteBatch.DrawString(fontSkali, nazwaSkali, new Vector2(400,100), Color.White);
            //spriteBatch.DrawString(fontSkali, czas.ToString(), new Vector2(400, 200), Color.White);
            spriteBatch.Draw(teksturaGryfu, hitboxTest, Color.White);


            if (msRect.Intersects(btnRects[2]))
            {
                spriteBatch.Draw(btns[2], btnRects[2], Color.Gray);
            }

            for (int i = 0; i < nuty.Length; i++)
            {
                spriteBatch.Draw(nuty[i], nutyRects[i], Color.White);
                spriteBatch.DrawString(fontNuty, nutyText[i], new Vector2(nutyRects[i].X + nuty[i].Width/4, nutyRects[i].Y + nuty[i].Height/5), Color.White);

                if (msRect.Intersects(nutyRects[i]))
                {
                    spriteBatch.Draw(nuty[i], nutyRects[i], Color.Gray);
                    spriteBatch.DrawString(fontNuty, nutyText[i], new Vector2(nutyRects[i].X + nuty[i].Width/4, nutyRects[i].Y + nuty[i].Height/5), Color.Gray);
                }
            }
        }
    }
}