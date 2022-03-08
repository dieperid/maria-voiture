using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace SFML_Engine
{ 
    abstract class Widget
    {
        protected Vector2f _position; //Widget's position
        protected Vector2f _size; //Widget's size
        protected Color _color; //Widget's color
        protected InputHandler _inputHandler; // Handles input

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ih"> Input handler </param>
        public Widget(InputHandler ih)
        {
            _inputHandler = ih;
            _color = Color.White;
        }

        /// <summary>
        /// Update widget
        /// </summary>
        /// <param name="dt"> Delta time </param>
        public abstract void Update(float dt);
        /// <summary>
        /// Render widget
        /// </summary>
        /// <param name="w"> Used window </param>
        public abstract void Render(RenderWindow w);

        /// <summary>
        /// Get/Set position
        /// </summary>
        public Vector2f Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// Get/Set position
        /// </summary>
        public Vector2f Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Get/Set color
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
}
