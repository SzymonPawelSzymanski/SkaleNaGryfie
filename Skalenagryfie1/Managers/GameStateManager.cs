using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Skalenagryfie1.Core;
using System.Collections.Generic;
using System.Text;
using Skalenagryfie1.Content.States;

namespace Skalenagryfie1.Managers
{
    internal partial class GameStateManager : Component
    {
        private MenuState ms = new MenuState();
        private GameState gs = new GameState();
        private Howto2State hts = new Howto2State();

        internal override void LoadContent(ContentManager Content)
        {
            ms.LoadContent(Content);
            gs.LoadContent(Content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.States.Menu:
                    ms.Draw(spriteBatch);
                    break;
                case Data.States.Game:
                    gs.Draw(spriteBatch);
                    break;
                case Data.States.Howto2:
                    hts.Draw(spriteBatch);
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.States.Menu:
                    ms.Update(gameTime);
                    break;
                case Data.States.Game:
                    gs.Update(gameTime);
                    break;
                case Data.States.Howto2:
                    hts.Update(gameTime);
                    break;
            }
        }

        
    }
}
