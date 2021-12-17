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
    internal class Howto2State : Component//dziedziczy wszycho po klasie State (astrakcyjnej ktora sluzy tylko do dziedziczenia)
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
                spriteBatch.Draw(teksturaGryfu, new Rectangle(100, 500, teksturaGryfu.Width, teksturaGryfu.Height), Color.White);
            }

            //foreach (var component in _components)
            //   component.Draw(spriteBatch);

            //spriteBatch.End();
        }
    }
}



/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Content.States
{
    internal class GameState : Component
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Component> _components;
        /*public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var teksturaGryfu = content.Load<Texture2D>("Tekstury/gryfBasowy1200");
            var teksturaNutki = content.Load<Texture2D>("Tekstury/tlonutki40");
            var fontNutki = content.Load<SpriteFont>("nutkafont");

            var mainGryf = new Bassgryf(teksturaGryfu)
            {
                gPosition = new Vector2(30, 400)
            };

            var nutka1 = new Nutka(teksturaNutki, fontNutki)
            {
                nPosition = new Vector2(150, 600),
                Text = "E",
            };

            var nutka2 = new Nutka(teksturaNutki, fontNutki)
            {
                nPosition = new Vector2(200, 600),
                Text = "G",
            };

            var nutka3 = new Nutka(teksturaNutki, fontNutki)
            {
                nPosition = new Vector2(250, 600),
                Text = "A",
            };

            var nutka4 = new Nutka(teksturaNutki, fontNutki)
            {
                nPosition = new Vector2(300, 600),
                Text = "B",
            };

            var nutka5 = new Nutka(teksturaNutki, fontNutki)
            {
                nPosition = new Vector2(350, 600),
                Text = "D",
            };

            _components = new List<Component>()
            {
                mainGryf,
                nutka1,
                nutka2,
                nutka3,
                nutka4,
                nutka5,
            };
        }*/
/*
        internal override void LoadContent(ContentManager Content)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //foreach (var component in _components)
            //    component.Draw(spriteBatch);
        }


        public override void Update(GameTime gameTime)
        {
            //foreach (var component in _components)
             //   component.Update(gameTime);
        }
    }
}*/