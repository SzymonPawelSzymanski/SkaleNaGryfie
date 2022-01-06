using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Skalenagryfie1.Content;
using Skalenagryfie1.Content.States;
using Skalenagryfie1.Core;
using Skalenagryfie1.Managers;


namespace Skalenagryfie1
{
    public class Game1 : Game
    {
        /// <summary>
        /// Główna klasa gry
        /// </summary>

        public static GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Color _backgroundColor = new Color(new Vector3(0.145f, 0.149f, 0.145f));
        SpriteFont tytulStrony;
        private GameStateManager gsm;
        public static int ktora_gra = 0;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
         
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Data.ScreenW;
            graphics.PreferredBackBufferHeight = Data.ScreenH; 
            graphics.ApplyChanges();
            gsm = new GameStateManager();
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tytulStrony = Content.Load<SpriteFont>("Fonts/galleryFont");
            gsm.LoadContent(Content);

            
        }

        protected override void Update(GameTime gameTime)
        {

            gsm.Update(gameTime);

            if(Data.Exit == true)
            {
                Exit();
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColor);

            spriteBatch.Begin();
            spriteBatch.DrawString(tytulStrony, "SKALE NA GRYFIE", new Vector2(370, 20), Color.White);
            gsm.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
