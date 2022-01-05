using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Skalenagryfie1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Content.States
{
    internal class MenuState : Component//dziedziczy wszycho po klasie State (astrakcyjnej ktora sluzy tylko do dziedziczenia)
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Component> _components;
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


        internal override void LoadContent(ContentManager Content)
        {
            teksturaGryfu = Content.Load<Texture2D>("Tekstury/rysunek_gryf_1");
            tablicadur = Content.Load<Texture2D>("Tekstury/tablicadur");
            tablicamol = Content.Load<Texture2D>("Tekstury/tablicamol");
            tablicalosowo = Content.Load<Texture2D>("Tekstury/tablicalosowo");
            fontSkali = Content.Load<SpriteFont>("Fonts/skalafont");
            const int INCREMENT = 150;
            const int INCREMENT_2 = 45;
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
            }

        }

        public override void Update(GameTime gameTime)
        {
            oldMs = ms;
            ms = Mouse.GetState();
            msRect = new Rectangle(ms.X, ms.Y, 1, 1);
            
            if(ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRects[0]))
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

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(teksturaGryfu, new Rectangle(35, -100, teksturaGryfu.Width, teksturaGryfu.Height), Color.White);
            spriteBatch.DrawString(fontSkali, "USTAWIENIA SKALI", new Vector2(80, 330), Color.White);
            spriteBatch.Draw(tablicamol, new Rectangle(110 - tablicadur.Width/2, 385, tablicadur.Width, tablicadur.Height), Color.White);
            spriteBatch.Draw(tablicadur, new Rectangle(220 - tablicadur.Width/2, 385, tablicadur.Width, tablicadur.Height), Color.White);
            spriteBatch.Draw(tablicalosowo, new Rectangle(380 - tablicalosowo.Width/2, 385, tablicalosowo.Width, tablicalosowo.Height), Color.White);
            if(msRect.Intersects(new Rectangle(380 - tablicalosowo.Width / 2, 385, tablicalosowo.Width, tablicalosowo.Height)))
            {
                spriteBatch.Draw(tablicalosowo, new Rectangle(380 - tablicalosowo.Width / 2, 385, tablicalosowo.Width, tablicalosowo.Height), Color.Gray);

            }


            for (int i = 0; i < 3; i++)
            {
                spriteBatch.Draw(btns[i], btnRects[i], Color.White);
                if (msRect.Intersects(btnRects[i]))
                {
                    spriteBatch.Draw(btns[i], btnRects[i], Color.Gray);
                }
            }

            for (int i = 0; i < note_btns.Length; i++)
            {
                spriteBatch.Draw(note_btns[i], note_btnRects[i], Color.White);
                spriteBatch.Draw(note_btns_2[i], note_btnRects_2[i], Color.White);
                if (msRect.Intersects(note_btnRects[i]))
                {
                    spriteBatch.Draw(note_btns[i], note_btnRects[i], Color.Gray);
                }
                else if (msRect.Intersects(note_btnRects_2[i]))
                {
                    spriteBatch.Draw(note_btns_2[i], note_btnRects_2[i], Color.Gray);
                }
            }

            //dopisz zmiane kolorow jak zaznaczysz ustawienie na glownym ekranie


            //foreach (var component in _components)
            //   component.Draw(spriteBatch);

            //spriteBatch.End();
        }
    }
}
