using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace feature_outside
{
    class Grass
    {
        //Attributes and properties
        public FloatRect Collider { get; set; }
        public RectangleShape Shape { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shape">Shape of the grass map</param>
        /// <param name="position">Position of the shape</param>
        public Grass(RectangleShape shape, Vector2f position)
        {
            Shape = shape;
            Shape.Position = position;
            Shape.FillColor = new Color(0, 153, 0);
            Collider = Shape.GetGlobalBounds();
        }
    }
}
