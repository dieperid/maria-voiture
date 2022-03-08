using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_Engine
{
    internal class InputHandler
    {
        const int NBR_OF_KEYS = (int)Keyboard.Key.KeyCount;
        const int NBR_OF_BUTTONS = (int)Mouse.Button.ButtonCount;
        const int STATE_ARRAY_SIZE = NBR_OF_BUTTONS + NBR_OF_KEYS;
        bool[] _oldState = new bool[STATE_ARRAY_SIZE]; //Contains the old state of keyboard's keys
        bool[] _actState = new bool[STATE_ARRAY_SIZE]; //Contains the actual state of keyboard's keys
        RenderWindow _window;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="w"> Used window </param>
        public InputHandler(RenderWindow w)
        {
            _window = w;
        }

        /// <summary>
        /// Updates the actual states of keys
        /// </summary>
        public void Update()
        {
            //Update the old state
            Array.Copy(_actState, _oldState, _actState.Length);

            //Update the actual state
            for (int i = 0; i < STATE_ARRAY_SIZE; i++)
            {
                if(i < NBR_OF_KEYS)
                {
                    if (Keyboard.IsKeyPressed((Keyboard.Key)i))
                    {
                        _actState[i] = true;
                    }
                    else
                    {
                        _actState[i] = false;
                    }
                }
                else
                {
                    if (Mouse.IsButtonPressed((Mouse.Button)(i - NBR_OF_KEYS)))
                    {
                        _actState[i] = true;
                    }
                    else
                    {
                        _actState[i] = false;
                    }
                }
            }
        }

        /// <summary>
        /// Verify if a key is pressed
        /// </summary>
        /// <param name="key"> Key to verify </param>
        /// <returns> True if key is pressed </returns>
        public bool IsPressed(Keyboard.Key key)
        {
            if (_actState[(int)key])
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Verify if a mouse button is pressed
        /// </summary>
        /// <param name="button"> Button to verify </param>
        /// <returns> True if button is pressed </returns>
        public bool IsPressed(Mouse.Button button)
        {
            if (_actState[NBR_OF_KEYS + (int)button])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verify if a key is clicked
        /// </summary>
        /// <param name="key"> Key to verify </param>
        /// <returns> True if key is clicked </returns>
        public bool IsClicked(Keyboard.Key key)
        {
            if(!_oldState[(int)key] && _actState[(int)key])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verify if a mouse button is clicked
        /// </summary>
        /// <param name="button"> Button to verify </param>
        /// <returns> True if button is clicked </returns>
        public bool IsClicked(Mouse.Button button)
        {
            if (!_oldState[NBR_OF_KEYS + (int)button] && _actState[NBR_OF_KEYS + (int)button])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verify if a key is released
        /// </summary>
        /// <param name="key"> Key to verify </param>
        /// <returns> True if key is released </returns>
        public bool IsReleased(Keyboard.Key key)
        {
            if (_oldState[(int)key] && !_actState[(int)key])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verify if a mouse button is released
        /// </summary>
        /// <param name="button"> Button to verify </param>
        /// <returns> True if button is released </returns>
        public bool IsReleased(Mouse.Button button)
        {
            if (_oldState[NBR_OF_KEYS + (int)button] && !_actState[NBR_OF_KEYS + (int)button])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get mouse position
        /// </summary>
        /// <param name="relative"> Determine if the returned position is relative to the window </param>
        /// <returns> Mouse position </returns>
        public Vector2i GetMousePosition(bool relative)
        {
            if (relative)
            {
                return Mouse.GetPosition(_window);
            }
            else
            {
                return Mouse.GetPosition();
            }
        }
    }
}
