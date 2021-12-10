using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Content.States
{
    public abstract class State
    {
        #region Fields

        protected ContentManager _content; //zarzadza Contentem?
        protected SpriteBatch _spriteBatch;
        protected GraphicsDevice _graphicsDevice; //no grafika?
        protected Game1 _game; //gra?

        #endregion

        #region Metody

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch); //rysowanie gry?
        public abstract void PostUpdate(GameTime gameTime); //wywala komponenty z listy
        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }
        public abstract void Update(GameTime gameTime);

        #endregion
    }
}
