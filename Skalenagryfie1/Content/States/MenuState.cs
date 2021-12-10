using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Content.States
{
    public class MenuState : State //dziedziczy wszycho po klasie State (bastrakcyjnej ktora sluzy tylko do dziedziczenia)
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Component> _components;
        public SpriteFont tytulStrony;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var tytulStrony = _content.Load<SpriteFont>("galleryFont");
            var buttonTexture = _content.Load<Texture2D>("przycisk");
            var buttonFont = _content.Load<SpriteFont>("buttonfont");

            var newGameButton = new Button(buttonTexture, buttonFont)
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
            };
        }

        private void HowtoGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new HowToState(_game, _graphicsDevice, _content));
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            //tytul strony nie dziala\/
            //spriteBatch.DrawString(tytulStrony, "SKALE NA GRYFIE", new Vector2(320,50), Color.White);

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            //spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Wywal sprity jeśli nie są potrzebne
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}
