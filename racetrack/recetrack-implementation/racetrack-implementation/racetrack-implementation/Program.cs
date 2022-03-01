using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace racetrack_implementation
{
    class Program
    {
        static void Main()
        {
            int xCar = 188;
            int yCar = 560;
            //cam variable
            int x = 188;
            int y = 560;
            int camSpeed = 4;
            int camAreaSize = 500; //chage to 150
            bool camIslock = true;

            Color grass = new Color(14, 209, 69, 100);

            //fenetre
            RenderWindow window = new RenderWindow(new VideoMode(1920, 1080, 32), "Racetrack");
            window.SetVerticalSyncEnabled(true);
            window.Closed += CloseWindow;

            Texture map = new Texture(@"F:\01-Projets\Maria-voiture\maps\Map1.png");

            Texture car1Texture = new Texture(@"F:\01-Projets\Maria-voiture\cars\car1.png");

            RectangleShape car1Shape = new RectangleShape(new Vector2f(18, 48));
            car1Shape.Position = new Vector2f(xCar - 9, yCar - 24);
            car1Shape.Texture = car1Texture;
            car1Shape.Origin = new Vector2f(9, 24);
            car1Shape.FillColor = Color.White;

            RectangleShape rectangleShape = new RectangleShape(new Vector2f(1920, 1080));
            rectangleShape.Texture = map;


            View view = new View(new FloatRect(500, 500, camAreaSize, camAreaSize));

            Wall walls = new Wall();
            walls.CreateAllWallsMap1();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.SetView(view);
                window.Clear(grass);

                window.Draw(rectangleShape);
                window.Draw(car1Shape);

                foreach (RectangleShape wall in walls.walls)
                {
                    window.Draw(wall);
                }

                window.Display();

                //car
                if ((Keyboard.IsKeyPressed(Keyboard.Key.A)))
                {
                    if (x == xCar && y== yCar && camIslock == true)
                    {                        
                        x -= camSpeed;
                    }
                    xCar -= camSpeed;
                    car1Shape.Rotation = 270;
                    car1Shape.Origin = new Vector2f(14, 16);
                    car1Shape.Size = new Vector2f(28, 32);
                }
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.D)))
                {
                    if (x == xCar && y == yCar && camIslock == true)
                    {
                        x += camSpeed;
                    }
                    xCar += camSpeed;
                    car1Shape.Rotation = 90;
                    car1Shape.Origin = new Vector2f(14, 16);
                    car1Shape.Size = new Vector2f(28, 32);
                }
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.W)))
                {
                    if (x == xCar && y == yCar && camIslock == true)
                    {
                        y -= camSpeed;
                    }
                    yCar -= camSpeed;
                    car1Shape.Rotation = 0;
                    car1Shape.Origin = new Vector2f(9, 24);
                    car1Shape.Size = new Vector2f(18, 48);
                }
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.S)))
                {
                    if (x == xCar && y == yCar && camIslock == true)
                    {
                        y += camSpeed;
                    }
                    yCar += camSpeed;
                    car1Shape.Rotation = 180;
                    car1Shape.Origin = new Vector2f(9, 24);
                    car1Shape.Size = new Vector2f(18, 48);
                }
                car1Shape.Position = new Vector2f(xCar, yCar);

                //Cam
                if ((Keyboard.IsKeyPressed(Keyboard.Key.Left)) && x > 30)
                {
                    x -= camSpeed;
                    camIslock = false;
                }
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.Right)) && x < 1900)
                {
                    x += camSpeed;
                    camIslock = false;
                }
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.Up)) && y > 20)
                {
                    y -= camSpeed;
                    camIslock = false;
                }
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.Down)) && y < 1050)
                {
                    y += camSpeed;
                    camIslock = false;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    x = xCar;
                    y = yCar;
                    camIslock = true;
                }
                view.Center = new Vector2f(x, y);
            }
            void CloseWindow(object sender, EventArgs args)
            {
                Environment.Exit(0);
            }
        }
    }
}

