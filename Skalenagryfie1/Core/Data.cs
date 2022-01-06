using System;
using System.Collections.Generic;
using System.Text;

namespace Skalenagryfie1.Core
{        /// <summary>
         /// Tu znajduja sue ustawienia gry takie jak wielkosc ekranu, czy obecne okno
         /// </summary>
    public static class Data
    {

        public static int ScreenW { get; set; } = 1280;
        public static int ScreenH { get; set; } = 980;
        public static bool Exit { get; set; } = false;

        public enum States {Menu, Game, Howto2}
        public static States CurrentState { get; set; } = States.Menu;
    }
}
