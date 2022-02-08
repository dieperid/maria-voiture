using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML;
using SFML.Graphics.Glsl;

namespace SoundVolume
{
    class Program
    {
        static void Main()
        {
            //Properties
            RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Sound Volume");
            RectangleShape rectangleShape = new RectangleShape(new Vector2f(500, 5));
            CircleShape circleShape = new CircleShape(12);

            // Set properties
            rectangleShape.FillColor = Color.Yellow;
            rectangleShape.Position = new Vector2f(window.Size.X / 2 - rectangleShape.Size.X / 2, window.Size.Y / 2 - rectangleShape.Size.Y / 2);

            circleShape.FillColor = Color.Red;
            circleShape.Position = new Vector2f(window.Size.X / 2 - circleShape.Radius, window.Size.Y / 2 - circleShape.Radius);

            //Add event to close the window
            window.Closed += close;


            //SoundBuffer soundBuffer = new SoundBuffer();
            Sound sound = new Sound();
            sound.Play();

            //Instance the window
            while (window.IsOpen)
            {
                //Use to button on the window
                window.DispatchEvents();

                //Clear the window
                window.Clear();

                //Replace the window at the top of the screen
                if (window.Position.X < 0 || window.Position.Y < 0)
                {
                    window.Position = new Vector2i(Math.Abs(window.Position.X), Math.Abs(window.Position.Y));
                }
                if(window.Position.X != 0)
                {
                    window.Position = new Vector2i(window.Position.X - 1, window.Position.Y);
                }
                if(window.Position.Y != 0)
                {
                    window.Position = new Vector2i(window.Position.X, window.Position.Y - 1);
                }

                //Instance the properties
                window.Draw(rectangleShape);
                window.Draw(circleShape);

                sound.Volume = mooveCursor();

                window.Display();
            }

            //Close the window
            void close(object sender, EventArgs args)
            {
                Environment.Exit(0);
            }

            float mooveCursor()
            {
                if(Mouse.IsButtonPressed(Mouse.Button.Left) && checkMoseEnter(circleShape))
                {
                    circleShape.Position = new Vector2f(Mouse.GetPosition().X, circleShape.Position.Y);
                }
                return (((circleShape.Position.X + circleShape.Radius) - rectangleShape.Position.X) * 100) / rectangleShape.Size.X;
            }

            bool checkMoseEnter(CircleShape circle)
            {
                float middleX = circle.Position.X + circle.Radius;
                float middleY = circle.Position.Y - circle.Radius;

                if (Math.Sqrt(Math.Pow(middleY - Mouse.GetPosition().Y, 2) + Math.Pow(middleX - Mouse.GetPosition().X, 2)) <= circle.Radius)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
