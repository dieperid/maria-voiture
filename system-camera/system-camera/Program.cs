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

            List<Drawable> drawablesItems = new List<Drawable>();  //list d'item à afficher


            //création d'un retangle et ajout de celui-ci dans la liste (sert de repère par apport à la voiture)
            RectangleShape rectangleShape = new RectangleShape(new Vector2f(50, 100));
            rectangleShape.OutlineThickness = 10f;
            rectangleShape.OutlineColor = Color.Black;
            rectangleShape.FillColor = Color.Green;
            drawablesItems.Add(rectangleShape);

            ////////////////////////////////////////PROGRAMME//////////////////////////////////////////////

            //car 
            RectangleShape car = new RectangleShape(new Vector2f(70, 100));
            car.FillColor = Color.Red;
            drawablesItems.Add(car);

            //view 
            View camera = new View(new Vector2f(350, 300), new Vector2f(1700, 1600));

            //set de l'event
            window.Closed += CloseWindow;

            bool wantToMoveCamera = false; //this detect if user want ot move camera or not



            float x = 0, //middle position x of the car
                 y = 0;  //middle position y of the car

            //initialise the camera position
            CameraAutoFollowCar(window, camera, car);

            //boucle du jeu
            while (window.IsOpen)
            {
                //permet l'interaction avec la fenêtre
                window.DispatchEvents();

                //clear
                window.Clear(Color.Blue);

                //move the car (red rectangle)
                SimulationCarMove(car, car.Position.X, car.Position.Y);

                //this simulate button click event
                if (Keyboard.IsKeyPressed(Keyboard.Key.Delete) && wantToMoveCamera == false)
                {
                    //initialse the position
                    x = car.Position.X + car.Size.X / 2;
                    y = car.Position.Y + car.Size.Y / 2;

                    //set the bool
                    wantToMoveCamera = true;

                    Thread.Sleep(100);
                }

                CorrectingTheCameraPosition(window, camera, car, ref x, ref y);

                //if user want to control the camera
                if (wantToMoveCamera)
                {
                    //move camera
                    UserMoveCamera(window, camera, car, ref x, ref y);
                }
                else
                {
                    //follow car
                    CameraAutoFollowCar(window, camera, car);
                }

                //this simulate a second button click event (this time that mean he want to stop the control of the camera)
                if (Keyboard.IsKeyPressed(Keyboard.Key.Delete) && wantToMoveCamera == true)
                {
                    //set the bool
                    wantToMoveCamera = false;

                    //set the camera position on the car
                    CameraAutoFollowCar(window, camera, car);

                    Thread.Sleep(100);
                }                

                //display elements
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


        //////////////////////////////////////// View Methodes //////////////////////////////////////////////////// 

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

        /// <summary>
        /// this methode can move the position of the camera
        /// </summary>
        /// <param name="window">main game window</param>
        /// <param name="camera">view object</param>
        /// <param name="car">RectangleShape user car</param>
        /// <param name="x">middle position x of the car</param>
        /// <param name="y">middle position x of the car</param>
        public static void UserMoveCamera(RenderWindow window, View camera, RectangleShape car, ref float x, ref float y)
        {
            const float CAMERASPEED = 0.5f; //speed of the camera move
            float MARGIN = car.Size.Y;     //margin with the sides of the camera

            //détect wich key is pressed
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                //check if user can move the camera to this direction
                if (y > (car.Position.Y + car.Size.Y / 2) - (camera.Size.Y / 2) + car.Size.Y / 2 + MARGIN)
                {
                    //initialise y position
                    y -= CAMERASPEED;
                }
                else
                {
                    //rectifiy the y position
                    y = (car.Position.Y + car.Size.Y / 2) - (camera.Size.Y / 2) + car.Size.Y / 2 + MARGIN;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                //check if user can move the camera to this direction
                if (y < (car.Position.Y + car.Size.Y / 2) + (camera.Size.Y / 2) - car.Size.Y / 2 - MARGIN)
                {
                    //initialise y position
                    y += CAMERASPEED;
                }
                else
                {
                    //rectifiy the y position
                    y = (car.Position.Y + car.Size.Y / 2) + (camera.Size.Y / 2) - car.Size.Y / 2 - MARGIN;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                //check if user can move the camera to this direction
                if (x > (car.Position.X + car.Size.X / 2) - (camera.Size.X / 2) + car.Size.X / 2 + MARGIN)
                {
                    //initialise x position
                    x -= CAMERASPEED;
                }
                else
                {
                    //rectifiy the x position
                    x = (car.Position.X + car.Size.X / 2) - (camera.Size.X / 2) + car.Size.X / 2 + MARGIN;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                //check if user can move the camera to this direction
                if (x < (car.Position.X + car.Size.X / 2) + (camera.Size.X / 2) - car.Size.X / 2 - MARGIN)
                {
                    //initialise x position
                    x += CAMERASPEED;
                }
                else
                {
                    //rectifiy the x position
                    x = (car.Position.X + car.Size.X / 2) + (camera.Size.X / 2) - car.Size.X / 2 - MARGIN;
                }
            }

            //set the focus position of the camera
            camera.Center = new Vector2f(x, y);
            window.SetView(camera);
        }

        /// <summary>
        /// this methode correct the position of the camera (car can t disappear to the view)
        /// </summary>
        /// <param name="window">main game window</param>
        /// <param name="camera">view object</param>
        /// <param name="car">RectangleShape user car</param>
        /// <param name="x">middle position x of the car</param>
        /// <param name="y">middle position x of the car</param>
        public static void CorrectingTheCameraPosition(RenderWindow window, View camera, RectangleShape car, ref float x, ref float y)
        {
            float MARGIN = car.Size.Y;      //margin with the sides of the camera

            //check if user can move the camera to this direction
            if (!(x < (car.Position.X + car.Size.X / 2) + (camera.Size.X / 2) - car.Size.X / 2 - MARGIN))
            {
                //rectifiy the x position
                x = (car.Position.X + car.Size.X / 2) + (camera.Size.X / 2) - car.Size.X / 2 - MARGIN;
            }


            //check if user can move the camera to this direction
            if (!(x > (car.Position.X + car.Size.X / 2) - (camera.Size.X / 2) + car.Size.X / 2 + MARGIN))
            {
                //rectifiy the x position
                x = (car.Position.X + car.Size.X / 2) - (camera.Size.X / 2) + car.Size.X / 2 + MARGIN;
            }

            //check if user can move the camera to this direction
            if (!(y < (car.Position.Y + car.Size.Y / 2) + (camera.Size.Y / 2) - car.Size.Y / 2 - MARGIN))
            {
                //rectifiy the x position
                y = (car.Position.Y + car.Size.Y / 2) + (camera.Size.Y / 2) - car.Size.Y / 2 - MARGIN;
            }


            //check if user can move the camera to this direction
            if (!(y > (car.Position.Y + car.Size.Y / 2) - (camera.Size.Y / 2) + car.Size.Y / 2 + MARGIN))
            {
                //rectifiy the x position
                y = (car.Position.Y + car.Size.Y / 2) - (camera.Size.Y / 2) + car.Size.Y / 2 + MARGIN;
            }

            //set the focus position of the camera
            camera.Center = new Vector2f(x, y);
            window.SetView(camera);
        }

        ////////////////////////////////// Other Methodes ///////////////////////////////////////////
        
        
        /// <summary>
        /// simule the movement of the cars
        /// </summary>
        /// <param name="car"></param>
        /// <param name="carPositionX"></param>
        /// <param name="carPositionY"></param>
        public static void SimulationCarMove(RectangleShape car, float carPositionX, float carPositionY)
        {
            Random r = new Random();
            int direction = r.Next(1, 5);

            int CARSPEED = 1;

            if (direction == 1)
            {
                carPositionX -= CARSPEED;
                car.Position = new Vector2f(carPositionX, carPositionY);

            }
            if (direction == 2)
            {
                carPositionX += CARSPEED;           
                car.Position = new Vector2f(carPositionX, carPositionY);

            }
            if (direction == 3)
            {
                carPositionY -= CARSPEED;
                car.Position = new Vector2f(carPositionX, carPositionY);

            }
            if (direction == 4)
            {
                carPositionY += CARSPEED;
                car.Position = new Vector2f(carPositionX, carPositionY);
            }
        }
    }
}
