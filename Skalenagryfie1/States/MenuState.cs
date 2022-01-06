using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Skalenagryfie1.Core;
using Skalenagryfie1.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Content.States
{
    internal class MenuState : Component
    {
        /// <summary>
        /// Klasa odpowiedzialna za okno menu
        /// </summary>

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private List<Component> _components;
        private Song groove;
        public SpriteFont tytulStrony;
        private SpriteFont fontSkali;
        private MouseState ms, oldMs;
        private Rectangle msRect;
        private Texture2D teksturaGryfu;
        private Texture2D tablicadur;
        private Texture2D tablicamol;
        private Texture2D tablicalosowo;
        private const int MAX_BTNS = 5;
        private const int MAX_NOTE_BTNS = 12;
        private Texture2D[] btns = new Texture2D[MAX_BTNS];
        private Rectangle[] btnRects = new Rectangle[MAX_BTNS];
        private Texture2D[] note_btns = new Texture2D[MAX_NOTE_BTNS];
        private Texture2D[] note_btns_2 = new Texture2D[MAX_NOTE_BTNS];
        private Rectangle[] note_btnRects = new Rectangle[MAX_NOTE_BTNS];
        private Rectangle[] note_btnRects_2 = new Rectangle[MAX_NOTE_BTNS];
        private Color[] note_col = new Color[MAX_NOTE_BTNS];
        private Color[] note_col_2 = new Color[MAX_NOTE_BTNS];
        private Color tablicalosowo_col = Color.Yellow;
        private int ktora_skala = 2;
        private int ktory_przycisk = 13;
        public static int wybrany_tryb; //-1 - losowo/ 0 - 11 dur/12 - 23 mol
        public static string[] tab_wynikow = new string[10];

        /// <summary>
        ///  W tej metodzie ładowane są zasoby do gry - analogiczne w metodzie LoadContent na każdej stronie
        /// </summary>
        /// <param name="Content"></param>
        internal override void LoadContent(ContentManager Content)
        {
            this._content = Content;
            teksturaGryfu = Content.Load<Texture2D>("Tekstury/rysunek_gryf_1");
            tablicadur = Content.Load<Texture2D>("Tekstury/tablicadur");
            tablicamol = Content.Load<Texture2D>("Tekstury/tablicamol");
            tablicalosowo = Content.Load<Texture2D>("Tekstury/tablicalosowo");
            fontSkali = Content.Load<SpriteFont>("Fonts/skalafont");
            groove = Content.Load<Song>("Sounds/groove2");
            MediaPlayer.Volume -= 0.7f;
            MediaPlayer.Play(groove);
            const int INCREMENT = 150;
            const int INCREMENT_2 = 45;
            wybrany_tryb = -1;

            for (int i=0; i < btns.Length; i++)
            {
                btns[i] = Content.Load<Texture2D>($"Tekstury/btn{i+1}");
                btnRects[i] = new Rectangle(640- btns[i].Width/2, 450 + INCREMENT*i, btns[i].Width, btns[i].Height);
            }

            for (int i = 0; i < note_btns.Length; i++)
            {
                note_btns[i] = Content.Load<Texture2D>($"Tekstury/note_btn{i + 1}");
                note_btns_2[i] = Content.Load<Texture2D>($"Tekstury/note_btn{i + 1}");
                note_btnRects[i] = new Rectangle(110 - note_btns[i].Width / 2, 430 + INCREMENT_2 * i, note_btns[i].Width, note_btns[i].Height);
                note_btnRects_2[i] = new Rectangle(220 - note_btns[i].Width / 2, 430 + INCREMENT_2 * i, note_btns[i].Width, note_btns[i].Height);
                note_col[i] = Color.White;
                note_col_2[i] = Color.White;
            }

            for (int i = 0; i < 10; i++)
            {
                tab_wynikow[i] = " ";
            }

        }


        /// <summary>
        ///  Metoda odświeżająca stan gry 60 razy na sekundę
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if(Game1.ktora_gra == 9)
            {
                tab_wynikow[9] = tab_wynikow[8];
                tab_wynikow[8] = tab_wynikow[7];
                tab_wynikow[7] = tab_wynikow[6];
                tab_wynikow[6] = tab_wynikow[5];
                tab_wynikow[5] = tab_wynikow[4];
                tab_wynikow[4] = tab_wynikow[3];
                tab_wynikow[3] = tab_wynikow[2];
                tab_wynikow[2] = tab_wynikow[1];
                tab_wynikow[1] = tab_wynikow[0];
                Game1.ktora_gra = 0;
            }
            oldMs = ms;
            ms = Mouse.GetState();
            msRect = new Rectangle(ms.X, ms.Y, 1, 1);
            
            if(ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRects[0]))
            {
                GameStateManager.gs = new GameState();
                GameStateManager.gs.LoadContent(_content);
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

            if (msRect.Intersects(new Rectangle(380 - tablicalosowo.Width / 2, 385, tablicalosowo.Width, tablicalosowo.Height)))
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    tablicalosowo_col = Color.Yellow;
                    ktora_skala = 2;
                    ktory_przycisk = 13;
                    wybrany_tryb = -1;
                }
            }

            for (int i = 0; i < note_btns.Length; i++)
            {
                note_col[i] = Color.White;
                note_col_2[i] = Color.White;

                if (msRect.Intersects(note_btnRects[i]))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        ktora_skala = 0;
                        ktory_przycisk = i;
                        tablicalosowo_col = Color.White;
                        wybrany_tryb = i;
                    }
                }
                else if (msRect.Intersects(note_btnRects_2[i]))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        ktora_skala = 1;
                        ktory_przycisk = i;
                        tablicalosowo_col = Color.White;
                        wybrany_tryb = i + 12;

                    }
                }

                if (ktora_skala == 0 && ktory_przycisk == i)
                {
                    note_col[i] = Color.Yellow;
                }
                else if (ktora_skala == 1 && ktory_przycisk == i)
                {
                    note_col_2[i] = Color.Yellow;
                }
            }

        }

        /// <summary>
        ///  Metoda odpowiedzialna za wyświetlanie grafik, napisów i rysowanie po ekranie
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(teksturaGryfu, new Rectangle(35, -100, teksturaGryfu.Width, teksturaGryfu.Height), Color.White);
            spriteBatch.DrawString(fontSkali, "USTAWIENIA SKALI", new Vector2(80, 330), Color.White);
            spriteBatch.DrawString(fontSkali, "TABLICA WYNIKOW", new Vector2(850, 330), Color.White);
            spriteBatch.Draw(tablicamol, new Rectangle(110 - tablicadur.Width/2, 385, tablicadur.Width, tablicadur.Height), Color.White);
            spriteBatch.Draw(tablicadur, new Rectangle(220 - tablicadur.Width/2, 385, tablicadur.Width, tablicadur.Height), Color.White);
            spriteBatch.Draw(tablicalosowo, new Rectangle(380 - tablicalosowo.Width/2, 385, tablicalosowo.Width, tablicalosowo.Height), tablicalosowo_col);

            #region przycisk losowo hover

            if (msRect.Intersects(new Rectangle(380 - tablicalosowo.Width / 2, 385, tablicalosowo.Width, tablicalosowo.Height)))
            {
                spriteBatch.Draw(tablicalosowo, new Rectangle(380 - tablicalosowo.Width / 2, 385, tablicalosowo.Width, tablicalosowo.Height), Color.Gray);
            }

            #endregion

            #region przyciski menu

            for (int i = 0; i < 3; i++)
            {
                spriteBatch.Draw(btns[i], btnRects[i], Color.White);
                if (msRect.Intersects(btnRects[i]))
                {
                    spriteBatch.Draw(btns[i], btnRects[i], Color.Gray);
                }
            }

            #endregion

            #region przyciski ustawien nut

            for (int i = 0; i < note_btns.Length; i++)
            {
                note_col[i] = Color.White;
                note_col_2[i] = Color.White;

                if (ktora_skala == 0 && ktory_przycisk == i)
                {
                    note_col[i] = Color.Yellow;
                }
                else if (ktora_skala == 1 && ktory_przycisk == i)
                {
                    note_col_2[i] = Color.Yellow;
                }

                spriteBatch.Draw(note_btns[i], note_btnRects[i], note_col[i]);
                spriteBatch.Draw(note_btns_2[i], note_btnRects_2[i], note_col_2[i]);
                if (msRect.Intersects(note_btnRects[i]))
                { 
                    spriteBatch.Draw(note_btns[i], note_btnRects[i], Color.Gray); 
                }
                else if (msRect.Intersects(note_btnRects_2[i]))
                {
                    spriteBatch.Draw(note_btns_2[i], note_btnRects_2[i], Color.Gray); 
                }


            }

            #endregion

            #region tablica wynikow - wyniki

            for (int i = 0; i < 10; i++)
            {
                spriteBatch.DrawString(fontSkali, $"{i+1}. " + tab_wynikow[i], new Vector2(980, 385+i*45), Color.White);
            }

            #endregion
        }
    }
}
