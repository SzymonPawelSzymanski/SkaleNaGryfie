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
        #endregion

        #region Metody
        public Nutka(Texture2D nutatexture, SpriteFont nutafont)
        {
            teksturaNutki = nutatexture;
            fontNutki = nutafont;
        }
        internal override void LoadContent(ContentManager Content)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override void Update(GameTime gametime)
        {
            /*Stwórz początkową pozycje nutki - współrzędne
            stwórz liste/tablice nazw pól (progów z nutami) na gryfie wraz z odpowiadającymi im prostokątami (hitboxami)
            przy drag&dropie nut, po puszczeniu LPM aktualna pozycja nutki jest porównywana z tabelą współrzędnych
            jeżeli nazwa nuty == nazwa pola to zostaw tam nutkę
            jeżeli != to wróc nutkę do pozycji początkowej
            (zrób warunek żeby nie zostawiać nut po całym stole)*/
        }
        #endregion
    }
}
