using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameLobby
{
    class Player
    {
        private string _name;                   //Name of the player
        private RectangleShape _rectangle;      //Rectangle which contain the player name
        private Text _text;                     //Text of the rectangle

        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Rectangle which contain the player name
        /// </summary>
        public RectangleShape Rectangle
        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;
            }
        }

        /// <summary>
        /// Text of the rectangle
        /// </summary>
        public Text Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="rectangle">Rectangle which contain the player name</param>
        public Player(string name, RectangleShape rectangle)
        {
            _name = name;
            _rectangle = rectangle;
            _text = new Text(_name, new Font("../../../fonts/pixelart.ttf"), 50);
        }
    }
}
