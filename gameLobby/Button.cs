using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameLobby
{
    class Button
    {
        public FloatRect Bounds { get; set; }
        public RectangleShape ButtonShape { get; set; }

        public Button(RectangleShape rectangle)
        {
            Bounds = ButtonShape.GetGlobalBounds();
        }
    }
}
