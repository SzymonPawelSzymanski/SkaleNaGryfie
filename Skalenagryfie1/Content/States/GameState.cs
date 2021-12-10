using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Content.States
{
    class GameState : State
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Component> _components;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var teksturaGryfu = _content.Load<Texture2D>("Tekstury/gryfBasowy1200");
            var teksturaNutki = _content.Load<Texture2D>("Tekstury/tlonutki40");
            var fontNutki = _content.Load<SpriteFont>("nutkafont");

            var mainGryf = new Bassgryf(teksturaGryfu)
            {
                gPosition = new Vector2(30, 400)
            };

            var nutka1 = new Nutka(teksturaNutki, fontNutki)
            {
                nPosition = new Vector2(150, 600),
                Text = "Dis",
            };

            _components = new List<Component>()
            {
                mainGryf,
                nutka1
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}
