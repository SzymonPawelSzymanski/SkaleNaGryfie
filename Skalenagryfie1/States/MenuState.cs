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
        private MouseState ms, oldMs;
        private Rectangle msRect;
        private Texture2D teksturaGryfu;
        private const int MAX_BTNS = 3;
        private Texture2D[] btns = new Texture2D[MAX_BTNS];
        private Rectangle[] btnRects = new Rectangle[MAX_BTNS];


        internal override void LoadContent(ContentManager Content)
        {
            teksturaGryfu = Content.Load<Texture2D>("Tekstury/gryfBasowy1000");
            const int INCREMENT = 130;
            for (int i=0; i < btns.Length; i++)
            {
                btns[i] = Content.Load<Texture2D>($"Tekstury/btn{i+1}");
                btnRects[i] = new Rectangle(560, 300 + INCREMENT*i, btns[i].Width, btns[i].Height);
            }
        }

        //public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        //{
            //var tytulStrony = content.Load<SpriteFont>("galleryFont");
            //var buttonTexture = content.Load<Texture2D>("przycisk");
            // var buttonFont = content.Load<SpriteFont>("buttonfont");

            /*var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(560, 300),
                Text = "Nowa Gra"
            };

            var howtoGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(560, 400),
                Text = "Jak grac"
            };

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(560, 500),
                Text = "Wyjdz z gry"
            };


            newGameButton.Click += NewGameButton_Click;
            howtoGameButton.Click += HowtoGameButton_Click;
            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                howtoGameButton,
                quitGameButton
            };*/
        //}

        /*private void HowtoGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new HowToState(_game, graphicsDevice, content));
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        } */

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

            //foreach (var component in _components)
            //   component.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            //tytul strony nie dziala\/
            //spriteBatch.DrawString(tytulStrony, "SKALE NA GRYFIE", new Vector2(320,50), Color.White);

            for (int i = 0; i < btns.Length; i++)
            {
                spriteBatch.Draw(teksturaGryfu, new Rectangle(1, 1, teksturaGryfu.Width, teksturaGryfu.Height), Color.White);
                spriteBatch.Draw(btns[i], btnRects[i], Color.White);
                if (msRect.Intersects(btnRects[i]))
                {
                    spriteBatch.Draw(btns[i], btnRects[i], Color.Gray);
                }
            }

            //foreach (var component in _components)
            //   component.Draw(spriteBatch);

            //spriteBatch.End();
        }
    }
}
