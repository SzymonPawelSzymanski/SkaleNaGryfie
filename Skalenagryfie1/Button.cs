using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Skalenagryfie1
{   //komentarz testowy do GitHuba
    internal class Button : Component
    {

        #region Pola

        private MouseState _currentMouse;

        private SpriteFont _font;

        private bool _isHovering;

        private MouseState _previousState;

        private Texture2D _texture;

        #endregion

        #region Wlasciwiosci

        public event EventHandler Click;

        public bool Clicked { get; private set;}

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public String Text { get; set; }

        #endregion

        #region Metody

        public Button(Texture2D buttontexture, SpriteFont buttonfont) //tworzy przycisk z teksturą, czcionką i kolorem czcionki
        {
            _texture = buttontexture;
            _font = buttonfont;
            PenColour = Color.Black;
        }

        internal override void LoadContent(ContentManager Content) 
        {

        }

        public override void Draw(SpriteBatch spriteBatch) //rysuje przycisk i opisuje funkcje hover
        {
            var colour = Color.White;

            if (_isHovering)
            {
                colour = Color.Gray;
                spriteBatch.Draw(_texture, Rectangle, colour);
            }
            else spriteBatch.Draw(_texture, Rectangle, Color.White);
             
            if (!string.IsNullOrEmpty(Text)) //umieszcza tekst po srodku przycisku
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gametime) //caly czas sprawdza co sie dzieje z myszka 
        {
            _previousState = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1); //opisuje kursor jako prostokat 1x1 aby mozna bylo powiedziec jak koliduje z rzeczami na ekranie

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle)) //sprawdza czy myszka jest na przycisku
            {
                _isHovering = true;

                if(_currentMouse.LeftButton == ButtonState.Released && _previousState.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }

            }
        }

        #endregion 
    }
}
