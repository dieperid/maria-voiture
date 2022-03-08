using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Engine
{
    internal class Label : Widget
    {
        Text _text; //Contains text

        public Label(Font f, InputHandler ih) : base(ih)
        {
            _text = new Text("",f);
        }

        public override void Render(RenderWindow w)
        {
            _text.Position = _position;
            w.Draw(_text);
        }

        public override void Update(float dt)
        { 
        }

        /// <summary>
        /// Get/Set text
        /// </summary>
        public string Text
        {
            get { return _text.DisplayedString; }
            set { _text.DisplayedString = value; }
        }

        /// <summary>
        /// Get/Set text scale
        /// </summary>
        public Vector2f Scale
        {
            get { return _text.Scale; }
            set { _text.Scale = value; }
        }
    }
}
