﻿using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SoundVolume
{
    class Program
    {
        private static bool IsPressed = false;
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

            Font font = new Font("arial.ttf");
            Text positionZ = new Text("0", font);
            positionZ.Position = new Vector2f(rectangleShape.Position.X - positionZ.CharacterSize, rectangleShape.Position.Y);

            Text positionE = new Text("100", font);
            positionE.Position = new Vector2f(rectangleShape.Position.X + rectangleShape.Size.X, rectangleShape.Position.Y + rectangleShape.Size.Y);

            //Add event to close the window
            window.Closed += close;
            

            SoundBuffer soundBuffer = new SoundBuffer("Sound.ogg");
            Sound sound = new Sound(soundBuffer);
            sound.Play();

            //Main loop
            while (window.IsOpen)
            {
                //Use to button on the window
                window.DispatchEvents();

                

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

                sound.Volume = mooveCursor(circleShape, rectangleShape);

                //Clear the window
                window.Clear();

                //Render
                window.Draw(rectangleShape);
                window.Draw(circleShape);
                window.Draw(positionZ);
                window.Draw(positionE);
                window.Display();
            }

            //Close the window
            void close(object sender, EventArgs args)
            {
                Environment.Exit(0);
            }

            //Moove the cursor return:the sound volume
            float mooveCursor(CircleShape circle, RectangleShape rectangle)
            {
                //Check if the mouse button is push or not
                if(!Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    IsPressed = false;
                }
                else if(checkMoseEnter(circle) && Mouse.IsButtonPressed(Mouse.Button.Left) || IsPressed == true)
                {
                    IsPressed = true;
                }

                //Move the cursor
                if(IsPressed == true)
                {
                    //Gére les exception si le curseur veut sortir
                    if(circle.Position.X + circle.Radius > rectangle.Position.X && circle.Position.X + circle.Radius < rectangle.Position.X + rectangle.Size.X)
                    {
                        circle.Position = new Vector2f(Mouse.GetPosition(window).X - circle.Radius, circle.Position.Y);
                    }
                    else if(circle.Position.X + circle.Radius > rectangle.Position.X)
                    {
                        circle.Position = new Vector2f(rectangle.Position.X + rectangle.Size.X - circle.Radius - 1, circle.Position.Y);
                        IsPressed = false;
                    }
                    else if (circle.Position.X + circle.Radius < rectangle.Position.X + rectangle.Size.X)
                    {
                        circle.Position = new Vector2f(rectangle.Position.X - circle.Radius + 1, circle.Position.Y);
                        IsPressed = false;
                    }
                }
                return (((circle.Position.X + circle.Radius) - rectangle.Position.X) * 100) / rectangle.Size.X;
            }


            bool checkMoseEnter(CircleShape circle)
            {
                float middleX = circle.Position.X + circle.Radius;
                float middleY = circle.Position.Y + circle.Radius;

                if (Math.Sqrt(Math.Pow(middleY - Mouse.GetPosition(window).Y, 2) + Math.Pow(middleX - Mouse.GetPosition(window).X, 2)) <= circle.Radius)
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
