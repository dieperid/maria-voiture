using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;

namespace ConsoleApp1
{
    class Car
    {
        //Car attributes
        float _enginePower;
        float _turnSpeed;
        float _heigth;
        float _width;
        Sprite _sprite;

        //Max values
        float frictionMax = 500;
        float breakingMax = 500;

        //Car state
        float _speed;
        float _radian_Heading;
        float _percent_steering;
        float _percent_Brake;
        float _percent_Throttle;

        //Unit Vectors
        Vector2f _unit_Heading;
        Vector2f _unit_Velocity;
        Vector2f _unit_Left;
        Vector2f _unit_Right;

        //Vectors
        Vector2f _position;
        Vector2f _velocity;
        Vector2f _vec_friction;
        Vector2f _vec_traction;
        Vector2f _vec_breaking;

        //Dot product
        public float _dot_Vel_Heading;
        public float _dot_Vel_Left;
        public float _dot_Vel_Right;

        public float EnginePower { get => _enginePower; set => _enginePower = value; }
        public float TurnSpeed { get => _turnSpeed; set => _turnSpeed = value; }
        public float Steering { get => _percent_steering; set => _percent_steering = value; }
        public float Brake { get => _percent_Brake; set => _percent_Brake = value; }
        public float Throttle { get => _percent_Throttle; set => _percent_Throttle = value; }
        public float Heading { get => _radian_Heading; set => _radian_Heading = value; }
        public float Speed { get => _speed; }
        public Vector2f Position { get => _position; set => _position = value; }
        public Vector2f Velocity { get => _velocity; set => _velocity = value; }

        public Car(Vector2f p, float w, float h, Texture t)
        {
            _position = p;
            _enginePower = 500;
            _turnSpeed = (float)Math.PI / 2;
            _radian_Heading = (float)Math.PI;
            _width = w;
            _heigth = h;
            _sprite = new Sprite(t);
            _sprite.Scale = new Vector2f(_width/_sprite.Texture.Size.X, _heigth / _sprite.Texture.Size.Y);
            _sprite.Origin = new Vector2f(_sprite.Texture.Size.X/2, _sprite.Texture.Size.Y);
        }

        public void Update(float dt)
        {
            //Calculate car's speed
            _speed = (float)Math.Sqrt(_velocity.X * _velocity.X + _velocity.Y * _velocity.Y);

            //Calculate car's heading
            _radian_Heading += _percent_steering * _turnSpeed * dt;
            //Update sprite rotation
            _sprite.Rotation = _radian_Heading * 180 / (float)Math.PI + 90;

            //Calculate unit vectors
            _unit_Heading = NormalizeVector(_radian_Heading);
            _unit_Left = -Rotate90(_unit_Heading);
            _unit_Right = Rotate90(_unit_Heading);
            _unit_Velocity = NormalizeVector(_velocity);

            //Calculate friction and breaking vector only when velocity isn't zero
            if (!(_velocity.X == 0 && _velocity.Y == 0))
            {
                //Calculate needed dot product
                _dot_Vel_Heading = Dot(_unit_Velocity, _unit_Heading);
                _dot_Vel_Left = Dot(_unit_Left, _unit_Velocity);
                _dot_Vel_Right = Dot(_unit_Right, _unit_Velocity);

                //Calculate friction vector
                _vec_friction = _dot_Vel_Left < _dot_Vel_Right ? _unit_Left : _unit_Right;
                _vec_friction *= (1-_dot_Vel_Heading) * frictionMax;

                //Calculate breaking vector
                _vec_breaking = -_unit_Velocity * _percent_Brake * breakingMax;
            }

            //Calculate traction vector
            _vec_traction = _unit_Heading * _percent_Throttle * MaxEngineTraction();

            //Calculate velocity
            _velocity += (_vec_breaking * dt) + (_vec_friction * dt) + (_vec_traction * dt);

            //Calculate position
            _position += _velocity * dt;
        }


        public void Render(RenderWindow w)
        {
            _sprite.Position = _position;
            w.Draw(_sprite);
            RenderVector(w, _unit_Heading, Color.White, true);
            RenderVector(w, _unit_Velocity, Color.Yellow, true);
            RenderVector(w, _vec_traction, Color.Red, false);
            RenderVector(w, _vec_friction, Color.Green, false);
            RenderVector(w, _vec_breaking, Color.Blue, false);
        }

        public float MaxEngineTraction()
        {
            return _enginePower - ((_speed * _speed) / 400);
        }

        void RenderVector(RenderWindow w, Vector2f vec, Color color, bool norm)
        {
            Vertex[] vertices = new Vertex[2];
            vertices[0] = new Vertex(_position, color);
            if (norm) { vertices[1] = new Vertex(_position + (vec * 100), color); }
            else { vertices[1] = new Vertex(_position + vec, color); }
            w.Draw(vertices, PrimitiveType.Lines);
        }

        private Vector2f NormalizeVector(Vector2f vec)
        {
            float vecModule = (float)Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
            return new Vector2f(vec.X / vecModule, vec.Y / vecModule);
        }

        private Vector2f NormalizeVector(float angle)
        {
            return new Vector2f((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        private float Dot(Vector2f vec1, Vector2f vec2)
        {
            return vec1.X * vec2.X + vec1.Y * vec2.Y;
        }

        private Vector2f Rotate90(Vector2f vec)
        {
            return new Vector2f(-vec.Y, vec.X);
        }
    }
}
