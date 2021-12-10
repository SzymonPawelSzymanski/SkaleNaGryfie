using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Skalenagryfie1.Content;
using Skalenagryfie1.Content.States;

namespace Skalenagryfie1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Color _backgroundColor = new Color(new Vector3(0.145f, 0.149f, 0.145f)); //moj szary to new Color(new Vector3(0.145f, 0.149f, 0.145f))
        SpriteFont tytulStrony;
        Texture2D przyciskStart;
        Texture2D przyciskHowTo;
        Texture2D przyciskExit;
        SpriteFont poleInformacyjne;

        private State _currentState;
        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        private List<Component> _gameComponents;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            #region Stworzenie_pentatonik
            //STWORZENIE PENTATONIK MOLOWYCH
            var e_pent_mol = new Skala_pentatoniczna();
            var f_pent_mol = new Skala_pentatoniczna();
            var fis_pent_mol = new Skala_pentatoniczna();
            var g_pent_mol = new Skala_pentatoniczna();
            var gis_pent_mol = new Skala_pentatoniczna();
            var a_pent_mol = new Skala_pentatoniczna();
            var ais_pent_mol = new Skala_pentatoniczna();
            var h_pent_mol = new Skala_pentatoniczna();
            var c_pent_mol = new Skala_pentatoniczna();
            var cis_pent_mol = new Skala_pentatoniczna();
            var d_pent_mol = new Skala_pentatoniczna();
            var dis_pent_mol = new Skala_pentatoniczna();

            e_pent_mol.nazwa_skali = "Skala E mol Pentatoniczna";
            f_pent_mol.nazwa_skali = "Skala F mol Pentatoniczna";
            fis_pent_mol.nazwa_skali = "Skala Fis mol Pentatoniczna";
            g_pent_mol.nazwa_skali = "Skala G mol Pentatoniczna";
            gis_pent_mol.nazwa_skali = "Skala Gis mol Pentatoniczna";
            a_pent_mol.nazwa_skali = "Skala A mol Pentatoniczna";
            ais_pent_mol.nazwa_skali = "Skala Ais mol Pentatoniczna";
            h_pent_mol.nazwa_skali = "Skala H mol Pentatoniczna";
            c_pent_mol.nazwa_skali = "Skala C mol Pentatoniczna";
            cis_pent_mol.nazwa_skali = "Skala Cis mol Pentatoniczna";
            d_pent_mol.nazwa_skali = "Skala D mol Pentatoniczna";
            dis_pent_mol.nazwa_skali = "Skala Dis mol Pentatoniczna";

            e_pent_mol.wypelnij_skale("E", "G", "A", "H", "D");
            f_pent_mol.wypelnij_skale("F", "Gis", "Ais", "C", "Dis");
            fis_pent_mol.wypelnij_skale("Fis", "A", "H", "Cis", "E");
            g_pent_mol.wypelnij_skale("G", "Ais", "C", "D", "F");
            gis_pent_mol.wypelnij_skale("Gis", "B", "Cis", "Dis", "Fis");
            a_pent_mol.wypelnij_skale("A", "C", "D", "E", "G");
            ais_pent_mol.wypelnij_skale("Ais", "Cis", "Dis", "F", "Gis");
            h_pent_mol.wypelnij_skale("H", "D", "E", "Fis", "A");
            c_pent_mol.wypelnij_skale("C", "Dis", "F", "G", "Ais");
            cis_pent_mol.wypelnij_skale("Cis", "E", "Fis", "Gis", "H");
            d_pent_mol.wypelnij_skale("D", "F", "G", "A", "C");
            dis_pent_mol.wypelnij_skale("Dis", "Fis", "Gis", "Ais", "Cis");

            //STWORZENIE PENTATONIK DUROWYCH
            var e_pent_dur = new Skala_pentatoniczna();
            var f_pent_dur = new Skala_pentatoniczna();
            var fis_pent_dur = new Skala_pentatoniczna();
            var g_pent_dur = new Skala_pentatoniczna();
            var gis_pent_dur = new Skala_pentatoniczna();
            var a_pent_dur = new Skala_pentatoniczna();
            var ais_pent_dur = new Skala_pentatoniczna();
            var h_pent_dur = new Skala_pentatoniczna();
            var c_pent_dur = new Skala_pentatoniczna();
            var cis_pent_dur = new Skala_pentatoniczna();
            var d_pent_dur = new Skala_pentatoniczna();
            Skala_pentatoniczna dis_pent_dur = new Skala_pentatoniczna();

            e_pent_dur.nazwa_skali = "Skala E dur Pentatoniczna";
            f_pent_dur.nazwa_skali = "Skala F dur Pentatoniczna";
            fis_pent_dur.nazwa_skali = "Skala Fis dur Pentatoniczna";
            g_pent_dur.nazwa_skali = "Skala G dur Pentatoniczna";
            gis_pent_dur.nazwa_skali = "Skala Gis dur Pentatoniczna";
            a_pent_dur.nazwa_skali = "Skala A dur Pentatoniczna";
            ais_pent_dur.nazwa_skali = "Skala Ais dur Pentatoniczna";
            h_pent_dur.nazwa_skali = "Skala H dur Pentatoniczna";
            c_pent_dur.nazwa_skali = "Skala C dur Pentatoniczna";
            cis_pent_dur.nazwa_skali = "Skala Cis dur Pentatoniczna";
            d_pent_dur.nazwa_skali = "Skala D dur Pentatoniczna";
            //dis_pent_dur.nazwa_skali = "Skala Dis dur Pentatoniczna";


            e_pent_dur.wypelnij_skale("E", "Fis", "Gis", "H", "Cis");
            f_pent_dur.wypelnij_skale("F", "G", "A", "C", "D");
            fis_pent_dur.wypelnij_skale("Fis", "Gis", "Ais", "Cis", "Dis");
            g_pent_dur.wypelnij_skale("G", "A", "H", "D", "E");
            gis_pent_dur.wypelnij_skale("Gis", "Ais", "C", "Dis", "F");
            a_pent_dur.wypelnij_skale("A", "H", "Cis", "E", "Fis");
            ais_pent_dur.wypelnij_skale("Ais", "C", "D", "F", "G");
            h_pent_dur.wypelnij_skale("H", "Cis", "Dis", "Fis", "Gis");
            c_pent_dur.wypelnij_skale("C", "D", "E", "G", "A");
            cis_pent_dur.wypelnij_skale("Cis", "Dis", "F", "Gis", "Ais");
            d_pent_dur.wypelnij_skale("D", "E", "Fis", "A", "H");
            dis_pent_dur.wypelnij_skale("Dis", "F", "G", "Ais", "C");
            #endregion

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1024;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tytulStrony = Content.Load<SpriteFont>("galleryFont");
            //przyciskStart = Content.Load<Texture2D>("przyciskstart");
            //przyciskHowTo = Content.Load<Texture2D>("przyciskhowto");
            //przyciskExit = Content.Load<Texture2D>("przyciskexit");
            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);

            /* var startButton = new Button(Content.Load<Texture2D>("przycisk"), Content.Load<SpriteFont>("buttonFont"))
            {
                Position = new Vector2(320, 100),
                Text = "Random"
            };

            startButton.Click += StartButton_Click;

            var howtoButton = new Button(Content.Load<Texture2D>("przycisk"), Content.Load<SpriteFont>("buttonFont"))
            {
                Position = new Vector2(320, 200),
                Text = "How To"
            };

            howtoButton.Click += HowtoButton_Click;

            var quitButton = new Button(Content.Load<Texture2D>("przycisk"), Content.Load<SpriteFont>("buttonFont"))
            {
                Position = new Vector2(320, 300),
                Text = "Quit"
            };

            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>()
            {
                startButton,
                howtoButton,
                quitButton
            };

            // TODO: use this.Content to load your game content here
        }

        private void HowtoButton_Click(object sender, EventArgs e)
        {
            var randomcolour = new Random();
            _backgroundColor = new Color(randomcolour.Next(0, 255), randomcolour.Next(0, 255), randomcolour.Next(0, 255));
            Console.WriteLine("HOW TO");
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var randomcolour = new Random();
            _backgroundColor = new Color(randomcolour.Next(0,255), randomcolour.Next(0, 255), randomcolour.Next(0, 255));
            Console.WriteLine("START");*/
        }

        protected override void Update(GameTime gameTime)
        {
            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }

            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            
            //foreach (var component in _gameComponents)
             //   component.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColor);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(tytulStrony, "SKALE NA GRYFIE", new Vector2(370, 20), Color.White);
            //_spriteBatch.Draw(przyciskStart, new Vector2(320, 100), Color.White);
            //_spriteBatch.Draw(przyciskHowTo, new Vector2(320, 200), Color.White);
            //_spriteBatch.Draw(przyciskExit, new Vector2(320, 300), Color.White);

            //foreach (var component in _gameComponents)
            //    component.Draw(gameTime, _spriteBatch);

            _currentState.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
