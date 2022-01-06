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
    internal class Howto2State : Component
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private Texture2D instrukcja;
        public SpriteFont tytulStrony;
        private MouseState ms, oldMs;
        private Rectangle msRect;
        const int INCREMENT = 130;
        private const int MAX_BTNS = 5;
        private Texture2D[] btns = new Texture2D[MAX_BTNS];
        private Rectangle[] btnRects = new Rectangle[MAX_BTNS];
        public bool reset;


        internal override void LoadContent(ContentManager Content)
        {
            this._content = Content;
            instrukcja = Content.Load<Texture2D>("Tekstury/instrukcja");

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = Content.Load<Texture2D>($"Tekstury/btn{i + 1}");
                btnRects[i] = new Rectangle(1060, 600 + INCREMENT * i, btns[i].Width, btns[i].Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
            oldMs = ms;
            ms = Mouse.GetState();
            msRect = new Rectangle(ms.X, ms.Y, 1, 1);

            if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRects[2]))
            {
                Data.CurrentState = Data.States.Menu;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(instrukcja, new Rectangle(35, 20, instrukcja.Width, instrukcja.Height), Color.White);
            spriteBatch.Draw(btns[4], btnRects[2], Color.White);

            if (msRect.Intersects(btnRects[2]))
            {
                spriteBatch.Draw(btns[4], btnRects[2], Color.Gray);
            }
            
        }
    }
}


