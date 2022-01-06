using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Skalenagryfie1
{        /// <summary>
         /// Klasa, po której dziedziczą okna gry
         /// </summary>
    internal abstract class Component
    {

        /// <param name="Content"></param>
        internal abstract void LoadContent(ContentManager Content);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gametime);
    }
}
