using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace SFML_Engine
{
    internal class Button : Widget
    {
        bool _oldState = false; // Old button's state
        bool _state = false; // Actual button's state
        Text _text; //Button's text
        public event EventHandler ClickedEvent; //Clicked event
        public event EventHandler PressedEvent; //Pressed event
        public event EventHandler ReleasedEvent; //Released event


        public Button(Font f, InputHandler ih) : base(ih)
        {
            _text = new Text("", f);
        }

        public override void Update(float dt)
        {
            //Get mouse position
            int mouseX = _inputHandler.GetMousePosition(true).X;
            int mouseY = _inputHandler.GetMousePosition(true).Y;

            //Change button state if clicked
            if (mouseX >= _position.X && mouseX <= _position.X + _size.X && mouseY >= _position.Y && mouseY <= _position.Y + _size.Y)
            {
                if (_inputHandler.IsPressed(Mouse.Button.Left))
                {
                    _state = true;
                }
                else
                {
                    _state = false;
                }
            }

            //Trigger event when button is clicked
            if(!_oldState && _state)
            {
                ClickedEvent?.Invoke(this, EventArgs.Empty);
            }
            //Trigger event when button is released
            else if(_oldState && !_state)
            {
                ReleasedEvent?.Invoke(this, EventArgs.Empty);
            }
            //Trigger event when button is pressed
            if(_state)
            {
                PressedEvent?.Invoke(this, EventArgs.Empty);
            }

            //Update old button state
            _oldState = _state;
        }

        public override void Render(RenderWindow w)
        {
            RectangleShape shape = new RectangleShape(_size);
            shape.Position = _position;
            _text.Position = _position;
            shape.FillColor = _color;
            w.Draw(shape);
            w.Draw(_text);
        }

        /// <summary>
        /// Get/Set text
        /// </summary>
        public string Text
        {
            get { return _text.DisplayedString; }
            set { _text.DisplayedString = value; }
        }
    }
}
