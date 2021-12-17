using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Skalenagryfie1
{
    class Nutka : Component
    {
        #region Pola
        private Texture2D teksturaNutki;
        private SpriteFont fontNutki;
        private MouseState _currentMouse;
        private bool _isHovering;
        private MouseState _previousState;
        #endregion

        #region Wlasciwosci
        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 nPosition { get; set; }

        public Rectangle nRectangle
        {
            get
            {
                return new Rectangle((int)nPosition.X, (int)nPosition.Y, teksturaNutki.Width, teksturaNutki.Height);
            }
        }

        public String Text { get; set; }
        #endregion

        #region Metody


        public Nutka(Texture2D nutatexture, SpriteFont nutafont)
        {
            teksturaNutki = nutatexture;
            fontNutki = nutafont;
            PenColour = Color.Black;
        }
        internal override void LoadContent(ContentManager Content)
        {

        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (_isHovering)
            {
                colour = Color.Gray;
                spriteBatch.Draw(teksturaNutki, nRectangle, colour);
            }
            else spriteBatch.Draw(teksturaNutki, nRectangle, Color.White);

            if (!string.IsNullOrEmpty(Text)) //umieszcza tekst po srodku przycisku
            {
                var x = (nRectangle.X + (nRectangle.Width / 2)) - (fontNutki.MeasureString(Text).X / 2);
                var y = (nRectangle.Y + (nRectangle.Height / 2)) - (fontNutki.MeasureString(Text).Y / 2);
                spriteBatch.DrawString(fontNutki, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gametime)
        {
            /*Stwórz początkową pozycje nutki - współrzędne
            stwórz liste/tablice nazw pól (progów z nutami) na gryfie wraz z odpowiadającymi im prostokątami (hitboxami)
            przy drag&dropie nut, po puszczeniu LPM aktualna pozycja nutki jest porównywana z tabelą współrzędnych
            jeżeli nazwa nuty == nazwa pola to zostaw tam nutkę
            jeżeli != to wróc nutkę do pozycji początkowej
            (zrób warunek żeby nie zostawiać nut po całym stole)*/

            _previousState = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;


            if (mouseRectangle.Intersects(nRectangle)) //sprawdza czy myszka jest na nutce
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Pressed && _previousState.LeftButton == ButtonState.Pressed)
                {
                    nPosition = new Vector2(_currentMouse.X - (nRectangle.Width / 2), _currentMouse.Y - (nRectangle.Height / 2));
                }


            }
        }
        #endregion
    }
}
