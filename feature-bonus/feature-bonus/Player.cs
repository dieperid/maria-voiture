using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace feature_bonus
{
    class Player
    {
        //Attributes and properties
        public RectangleShape Shape { get; set; }
        private Vector2f _position;
        public float Speed { get; set; }
        public bool HaveBonus { get; set; }
        public BonusObject Bonus { get; set; }
        public FloatRect Collider { get; set; }
        private bool _isKeyPressed = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shape">Shape of the player</param>
        /// /// <param name="startPosition">Position of the player</param>
        /// <param name="speed">Speed of the player</param>
        public Player(RectangleShape shape, Vector2f startPosition, float speed)
        {
            Shape = shape;
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

            if (Keyboard.IsKeyPressed(Keyboard.Key.E) && !_isKeyPressed)
            {
                Console.WriteLine($"Player has used {Bonus.ToString()}");
                Bonus = BonusObject.Empty;
                HaveBonus = false;
                _isKeyPressed = true;
            }
            else if (!Keyboard.IsKeyPressed(Keyboard.Key.E))           
                _isKeyPressed = false;           

            Shape.Position = _position;
            Collider = Shape.GetGlobalBounds();
        }

        /// <summary>
        /// Get bonus from bonus box
        /// </summary>
        /// <param name="bonusToGet">Bonus that the player will get</param>
        public void GetBonusObject(BonusObject bonusToGet)
        {
            Bonus = bonusToGet;
            HaveBonus = true;
        }
    }
}
