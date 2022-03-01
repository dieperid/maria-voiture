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
            List<RectangleShape> cars = new List<RectangleShape>(); //list of all cars

            ////////////////////////////////////////PROGRAMME//////////////////////////////////////////////

            //car 
            RectangleShape firstCar = new RectangleShape(new Vector2f(70, 100));
            firstCar.FillColor = Color.Red;
            firstCar.Position = new Vector2f(50, 50);
            drawablesItems.Add(firstCar);
            cars.Add(firstCar);

            RectangleShape currentCar = new RectangleShape(new Vector2f(70, 100));
            currentCar.FillColor = Color.Black;
            currentCar.Position = new Vector2f(50, 250);
            drawablesItems.Add(currentCar);
            cars.Add(currentCar);

            RectangleShape thirdCar = new RectangleShape(new Vector2f(70, 100));
            thirdCar.FillColor = Color.Cyan;
            thirdCar.Position = new Vector2f(50, 450);
            drawablesItems.Add(thirdCar);
            cars.Add(thirdCar);

            //set de l'event
            window.Closed += CloseWindow;

            //boucle du jeu
            while (window.IsOpen)
            {
                //permet l'interaction avec la fenêtre
                window.DispatchEvents();

                //clear
                window.Clear(Color.Blue);

                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    CarSwapper(cars, currentCar);
                    InitialiseDrawableCars(drawablesItems, cars);
                    Thread.Sleep(200);
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
        /// this méthode is using for switch two cars
        /// </summary>
        /// <param name="cars">list of all cars</param>
        /// <param name="car">current cars (user)</param>
        public static void CarSwapper(List<RectangleShape> cars, RectangleShape playerCar)
        {
            int index = 0;
            foreach(RectangleShape car in cars)
            {
                if (car == playerCar)
                {
                    if (index != 0)
                    {
                        RectangleShape tempCar = new RectangleShape();
                        tempCar.Position = cars[index - 1].Position;
                        //tempCar = cars[index - 1];

                        //echanger les positions x y
                        cars[index - 1].Position = car.Position;
                        car.Position = tempCar.Position;

                        //changer de place les voitures dans la liste
                        cars[index - 1] = car;
                        cars[index] = tempCar;

                        break;
                    }
                    else
                     {
                        RectangleShape tempCar = new RectangleShape();
                        tempCar.Position = cars[cars.Count - 1].Position;
                        //tempCar = cars[cars.Count - 1];

                        //echanger les positions x y
                        cars[cars.Count - 1].Position = car.Position;
                        car.Position = tempCar.Position;

                        //changer de place les voitures dans la liste
                        cars[cars.Count - 1] = car;
                        cars[index] = tempCar;
                        break;
                    }
                }
                index++;
            } 
        } 
        public static void InitialiseDrawableCars(List<Drawable> drawableCars, List<RectangleShape> cars)
        {
            drawableCars.Clear();

            foreach(RectangleShape car in cars)
            {
                drawableCars.Add(car);
            }

        }
    }
}
