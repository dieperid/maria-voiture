///ETML
///Author : Kendy Song
///Date : 01.03.2022
///Summary : Contain a bonus, and visual of cube

using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace feature_bonus
{
    class Bonus
    {
        //Attributes and properties
        public RectangleShape Shape { get; set; }
        public FloatRect Collider { get; set; }
        public BonusObject Effect { get; set; }
        private Random _random;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shape">Shape of the bonus</param>
        /// <param name="position">Position of the bonus</param>
        /// <param name="color">Color of the bonus</param>
        public Bonus(RectangleShape shape, Vector2f position, int color, int seed)
        {
            Shape = shape;      
            Shape.Position = position;
            Shape.FillColor = SelectColor(color);
            Collider = Shape.GetGlobalBounds();

            _random = new Random(seed);
            switch (_random.Next(0, 3))
            {
                case 0:
                    Effect = BonusObject.Bomb;
                    break;

                case 1:
                    Effect = BonusObject.Missile;
                    break;

                case 2:
                    Effect = BonusObject.SpeedBoost;
                    break;
            }
        }

        /// <summary>
        /// Select a color with the number
        /// </summary>
        /// <param name="colorNumber">Color to select</param>
        /// <returns>Color selected</returns>
        private Color SelectColor(int colorNumber)
        {
            Color color = Color.White;
            switch (colorNumber)
            {
                case 0:
                    color = Color.Blue;
                    break;

                case 1:
                    color = Color.Red;
                    break;

                case 2:
                    color = Color.Green;
                    break;

                case 3:
                    color = Color.Magenta;
                    break;

                case 4:
                    color = Color.Cyan;
                    break;
            }

            return color;
        }
    }
}
