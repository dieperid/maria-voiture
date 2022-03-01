///ETML
///Author : Kendy Song
///Date : 08.02.2022
///Summary : Contain a player data 

using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace collision_detection
{
    /// <summary>
    /// Contain a player data 
    /// </summary>
    class Player
    {
        //Attributes and properties
        public Sprite Car { get; set; }
        private Vector2f _playerPosition;
        private float _speed;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="playerCar">Shape of the player</param>
        /// <param name="playerPosition">Position of the player</param>
        /// <param name="speed">Speed of the car of the player</param>
        public Player(Sprite playerCar, float speed)
        {
            _speed = speed;
            Car = playerCar;
        }

        /// <summary>
        /// Input and move the player
        /// </summary>
        /// <param name="deltaTime">Time between each frame</param>
        public void InputMovement(float deltaTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                _playerPosition.Y -= deltaTime * _speed;

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                _playerPosition.X -= deltaTime * _speed;

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                _playerPosition.Y += deltaTime * _speed;

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                _playerPosition.X += deltaTime * _speed;

            Car.Position = _playerPosition;
        }
    }
}
