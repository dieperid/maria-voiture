using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Engine
{
    internal class Slider : Widget
    {
        float _t; //Interpolated value
        float _min; //Min value
        float _max; //Max value
        float _value; //Value
        bool _drag; //Is dragged
        Text _text; //Slider's value in text
        Text _textValue; //Slider's text
        Vector2f _sliderPos; //Slider's position
        Vector2f _sliderSize; //Slider's size

        public Slider(string txt, Font f, InputHandler ih) : base(ih)
        {
            _text = new Text(txt, f);
            _textValue = new Text("", f);
            _size = new Vector2f(300,1);
            _textValue.Scale = new Vector2f(0.5f, 0.5f);
            _text.Scale = new Vector2f(0.5f, 0.5f);
            _sliderSize = new Vector2f(10, 30);
            _sliderPos = new Vector2f(_position.X, _position.Y - _sliderSize.Y / 2f);
        }

        public override void Render(RenderWindow w)
        {
            RectangleShape bar = new RectangleShape(new Vector2f(_size.X, 2));
            RectangleShape slider = new RectangleShape(_sliderSize);
            bar.FillColor = _color;
            bar.Position = new Vector2f(_position.X,_position.Y - _size.Y/2f);
            bar.OutlineColor = Color.Black;
            bar.OutlineThickness = 2;
            slider.FillColor = _color;
            slider.Position = _sliderPos;
            slider.OutlineColor = Color.Black;
            slider.OutlineThickness = 2;
            _textValue.DisplayedString = $"{_value:0.0}";
            _textValue.Position = new Vector2f(_sliderPos.X - _textValue.CharacterSize / 2f, _sliderPos.Y + 30);
            _text.Position = new Vector2f(_position.X - 5, _position.Y - 35);
            w.Draw(bar);
            w.Draw(slider);
            w.Draw(_textValue);
            w.Draw(_text);
        }

        public override void Update(float dt)
        {
            //_sliderPos.X = Math.Clamp(_sliderPos.X, _position.X, _position.X + _size.X);
            if(_sliderPos.X > _position.X + _size.X)
            {
                _sliderPos.X = _position.X + _size.X;
            }
            else if (_sliderPos.X < _position.X)
            {
                _sliderPos.X = _position.X;
            }
            _sliderPos.Y = _position.Y - _sliderSize.Y / 2f;
            float mouseX = _inputHandler.GetMousePosition(true).X;
            float mouseY = _inputHandler.GetMousePosition(true).Y;

            if (mouseX >= _sliderPos.X && mouseX <= _sliderPos.X + _sliderSize.X && mouseY >= _sliderPos.Y && mouseY <= _sliderPos.Y + _sliderSize.Y)
            {
                if (_inputHandler.IsClicked(Mouse.Button.Left))
                {
                    _drag = true;
                }
            }
            if(_inputHandler.IsReleased(Mouse.Button.Left) && _drag)
            {
                _drag = false;
            }
            if (_drag)
            {
                //_sliderPos.X = Math.Clamp(mouseX, _position.X, _position.X + _size.X);
                _sliderPos.X = mouseX;
            }

            _t = (_sliderPos.X - _position.X) / (_size.X);
            _value = _t * (_max - _min) + _min;
        }

        /// <summary>
        /// Get the slider percentage
        /// </summary>
        public float T
        {
            get { return _t; }
        }

        /// <summary>
        /// Get the slider value
        /// </summary>
        public float Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Get the min value
        /// </summary>
        public float Min
        {
            get { return _min; }
            set { _min = value; }
        }

        /// <summary>
        /// Get the max value
        /// </summary>
        public float Max
        {
            get { return _max; }
            set { _max = value; }
        }

        /// <summary>
        /// Get/Set slider text
        /// </summary>
        public string Text
        {
            get { return _text.DisplayedString; }
            set { _text.DisplayedString = value; }
        }
    }
}
