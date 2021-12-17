using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Skalenagryfie1.Content;
using Skalenagryfie1.Content.States;

namespace Skalenagryfie1
{
    internal class Bassgryf : Component
    {
        private Texture2D teksturaGryfu;

        public Bassgryf(Texture2D texture)
        { 
            teksturaGryfu = texture;
        }

        public Vector2 gPosition { get; set; }

        public Rectangle gRectangle
        {
            get
            {
                return new Rectangle((int)gPosition.X, (int)gPosition.Y, teksturaGryfu.Width, teksturaGryfu.Height);
            }
        }

        internal override void LoadContent(ContentManager Content)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(teksturaGryfu, gRectangle, Color.White);
        }

        public override void Update(GameTime gametime)
        {
            Console.WriteLine("Nic tu nie ma na razie");
        }
    }
}
