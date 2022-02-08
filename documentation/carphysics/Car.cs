using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Physics
{
    class Car
    {
        private float _width;
        private float _height;
        private float _speed;
        private float _frontWheeAngle;
        private float _acceleration;
        private float _heading;
        private float _breaking;
        private Vector2f _position;
        private Vector2f _velocity;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="w"> Width </param>
        /// <param name="h"> Height </param>
        /// <param name="s"> Speed </param>
        /// <param name="a"> Acceleration </param>
        /// <param name="he"> Heading </param>
        /// <param name="p"> Position </param>
        public Car(float w, float h, float s, float a, float he, Vector2f p)
        {
            _width = h;
            _height = w;
            _speed = s;
            _acceleration = a;
            _heading = he;
            _position = p;
            _breaking = 1;
            _velocity = new Vector2f(1, 0);
            _frontWheeAngle = 0;
        }

        public void Update(float dt)
        {
            _position += _velocity * dt;
            _heading = (float)Math.Atan2(_velocity.Y, _velocity.X) * 180 / (float)Math.PI;
        }

        public void Accelerate(float dt)
        {
            Vector2f velunit = _velocity / (float)Math.Sqrt(_velocity.X * _velocity.X + _velocity.Y * _velocity.Y);
            velunit *= _acceleration;
            _velocity += velunit * dt;
        }

        public void Break(float dt)
        {
            Vector2f breaking = _velocity * -1;
            _velocity += (breaking * _breaking) * dt;
        }

        public void Turn(bool left, float turnRate, float dt)
        {
            Vector2f leftvec = new Vector2f(_velocity.X * 0 + _velocity.Y * 1, _velocity.X * -1 + _velocity.Y * 0);
            leftvec = leftvec / (float)Math.Sqrt(leftvec.X * leftvec.X + leftvec.Y * leftvec.Y);
            Vector2f rightvec = leftvec * -1;
            if (left)
            {
                _velocity += leftvec * turnRate * dt;
            }
            else
            {
                _velocity += rightvec * turnRate * dt;
            }
        }

        public void Render(RenderWindow w)
        {
            RectangleShape rec = new RectangleShape(new Vector2f(_width,_height));
            rec.FillColor = Color.Red;
            rec.Position = _position;
            rec.Origin = new Vector2f(_width / 2f, _height / 2f);
            rec.Rotation = _heading;
            w.Draw(rec);
        }

        public Vector2f Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public float Acceleration
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public float Heading
        {
            get { return _heading; }
            set { _heading = value; }
        }

        public Vector2f Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
