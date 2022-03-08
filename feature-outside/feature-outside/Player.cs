///ETML
///Author : Kendy Song
///Date : 08.03.2022
///Summary : Player visual, movement and settings

using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace feature_outside
{
    class Player
    {
        //Attributes and properties
        public RectangleShape Shape { get; set; }
        private Vector2f _position;

        public float BaseSpeed { get; set; }
        public float Speed { get; set; }
        public bool HaveBonus { get; set; }
        public bool IsSlow { get; set; }
        public FloatRect Collider { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shape">Shape of the player</param>
        /// /// <param name="startPosition">Position of the player</param>
        /// <param name="speed">baseSpeed of the player</param>
        public Player(RectangleShape shape, Vector2f startPosition, float speed)
        {
            Shape = shape;

            BaseSpeed = speed;
            Speed = speed;

            Shape.Position = startPosition;
            _position = startPosition;
            Collider = Shape.GetGlobalBounds();
            HaveBonus = false;

        }

        /// <summary>
        /// Move the player
        /// </summary>
        /// <param name="deltaTime">Time for move the player</param>
        public void InputMove(float deltaTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                _position.Y -= deltaTime * Speed;

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                _position.X -= deltaTime * Speed;

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                _position.Y += deltaTime * Speed;

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                _position.X += deltaTime * Speed;

            Shape.Position = _position;
            Collider = Shape.GetGlobalBounds();
        }
    }
}
