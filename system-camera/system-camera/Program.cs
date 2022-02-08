using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.Threading;


namespace system_camera
{
    class Program
    {
        static void Main()
        {
            //créer une nouvelle fenêtre
            RenderWindow window = new RenderWindow(new VideoMode(900, 900), "First-Programm");

           


            window.SetVerticalSyncEnabled(true);

            List<Drawable> drawablesItems = new List<Drawable>();  //list d'item à afficher

            ////////////////////////////////FORMES AND TEXTURES///////////////////////////////

            //création d'une texture
            Texture circleTexture = new Texture(@"F:\test\git.png");
            circleTexture.Smooth = true;

            //création d'un sprite
            Texture triangleTexture = new Texture(@"F:\test\git.png");
            triangleTexture.Smooth = true;

            CircleShape circleShapeTwo = new CircleShape(50, 20);
            circleShapeTwo.Position = new Vector2f(200, 400);
            circleShapeTwo.OutlineThickness = 10f;
            circleShapeTwo.OutlineColor = Color.Black;       
            circleShapeTwo.Texture = circleTexture;
            drawablesItems.Add(circleShapeTwo);

            //création d'un retangle et ajout de celui-ci dans la liste
            RectangleShape rectangleShape = new RectangleShape(new Vector2f(50, 100));
            rectangleShape.OutlineThickness = 10f;
            rectangleShape.OutlineColor = Color.Black;
            rectangleShape.FillColor = Color.Green;
            drawablesItems.Add(rectangleShape);


            RectangleShape car = new RectangleShape(new Vector2f(70, 100));
            car.FillColor = Color.Red;
            drawablesItems.Add(car);


            //create a triangle
            CircleShape triangle = new CircleShape(70, 3);
            triangle.Position = new Vector2f(20, 400);
            triangle.Texture = triangleTexture;
            drawablesItems.Add(triangle);

            View camera = new View(new Vector2f(350, 300), new Vector2f(500, 400));

            ////////////////////////////////////////PROGRAMME//////////////////////////////////////////////

            //set de l'event
            window.Closed += CloseWindow;

            float x = car.Position.X,
                  y = car.Position.Y;

            
            //boucle du jeu
            while (window.IsOpen)
            {
                //permet l'interaction avec la fenêtre
                window.DispatchEvents();

                //texture.Update(window);

                window.Clear(Color.Blue);


                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    x -= 5;
                    car.Position = new Vector2f(x, y);
                    
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    x += 5;
                    car.Position = new Vector2f(x, y);
                
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    y -= 5;
                    car.Position = new Vector2f(x, y);
                
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    y += 5;
                    car.Position = new Vector2f(x, y);               
                }

                CameraAutoFollowCar(window, camera, car);



                //affichages des éléments
                foreach (Drawable shapes in drawablesItems)
                {
                    window.Draw(shapes);
                }

                //display dans la fenêtre
                window.Display();
            }

            void CloseWindow(object sender, EventArgs args)
            {
                window.Close();
            }
        }
        /// <summary>
        /// this methode is using to follow the user car
        /// </summary>
        /// <param name="window">main game window</param>
        /// <param name="camera">View object (camera)</param>
        /// <param name="car">RectangleShape user car</param>
        public static void CameraAutoFollowCar(RenderWindow window, View camera, RectangleShape car)
        {
            camera.Center = new Vector2f(car.Position.X + car.Size.X / 2, car.Position.Y + car.Size.Y / 2);
            window.SetView(camera);
        }

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
        public static void UserMoveCamera(RenderWindow window, View camera, RectangleShape car)
        {
            const float SPEED = 3;

            float x = car.Position.X + car.Size.X / 2,
                  y = car.Position.Y + car.Size.Y / 2;

            bool returnToCar = false;

            do
            {

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    camera.Center = (new Vector2f(x, y -= SPEED));
                    window.SetView(camera);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    camera.Center = (new Vector2f(x, y += SPEED));
                    window.SetView(camera);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    camera.Center = (new Vector2f(x -= SPEED, y));
                    window.SetView(camera);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    
                    camera.Center = (new Vector2f(x += SPEED, y));
                    window.SetView(camera);
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    returnToCar = true;
                }
                                           
                
            }
            while (!returnToCar);
        }

    }
}
