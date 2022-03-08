///ETML
///Auteur : Alexandre King
///Date : 25.01.22
///Description : classe principal du programme
using System;
using System.Collections.Generic;
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
            //tout le code en rapport avec la voiture sera remplacer par celui qui s'en occupe!
            //car variable            
            int xCar = 188;     //position X de la voiture
            int yCar = 560;     //position Y de la voiture
            int carSizeX = 18;  //largeur de la voiture
            int carSizeY = 48;  //longuer de la voiture
            //cam variable
            int x = 188;        //position X de la cam
            int y = 560;        //position Y de la cam
            int camSpeed = 4;   //vitesse de déplacement de la cam
            int camAreaSize = 500; //taille de la zone que la cam voit
            bool camIslock = true;  //si la cam est lock sur la voiture ou pas. (true = lock, false = pas lock)

            //other variable
            Color grass = new Color(14, 209, 69, 100);  //couleur de l'herbe

            //window
            RenderWindow window = new RenderWindow(new VideoMode(1920, 1080, 32), "Racetrack"); //création de la fenetre
            window.SetVerticalSyncEnabled(true);                                                //active la synchronisation verticale de la fenetre
            window.Closed += CloseWindow;                                                       //ajoute un méthode pour si la fenetre est fermée

            //texture
            Texture mapTexture = new Texture(@"F:\01-Projets\Maria-voiture\maps\Map1.png");     //texture de la map (rajouter : -WithoutSecretPath après map pour enlever le paasage secret
            Texture car1Texture = new Texture(@"F:\01-Projets\Maria-voiture\cars\car1.png");    // texture de la voiture

            //Car
            RectangleShape car1Shape = new RectangleShape(new Vector2f(carSizeX, carSizeY));    //rectangle pour la voiture
            car1Shape.Position = new Vector2f(xCar - carSizeX/2, yCar - carSizeY/2);            //position de la voiture 
            car1Shape.Texture = car1Texture;                                                    //texture de la voiture
            car1Shape.Origin = new Vector2f(carSizeX/2, carSizeY/2);                            //point d'origin de la voiture (centre de la voiture)            

            //map
            RectangleShape mapShape = new RectangleShape(new Vector2f(1920, 1080));             //rectangle pour la map
            mapShape.Texture = mapTexture;                                                      //texture de la map (a modifier pour avoir les 4 maps)

            //view
            View view = new View(new FloatRect(500, 500, camAreaSize, camAreaSize));            //création d'une view pour gérer la caméra

            //création des murs 
            Wall walls = new Wall();                                                            //nouveaux murs 
            walls.CreateAllWallsMap1();                                                         //créer tout les murs (a changer pour aller avec la bonne map)

            //boucle principal pour gérer lorsque la fenetre est ouverte
            while (window.IsOpen)
            {
                //configure la vue et clear la console avec la couleur de l'herbe (comme ça pas de problème de map trop petite)
                window.DispatchEvents();
                window.SetView(view);
                window.Clear(grass);
                //dessine la map et la voiture
                window.Draw(mapShape);
                window.Draw(car1Shape);

                //pour chaque murs, les dessinent
                foreach (RectangleShape wall in walls.walls)
                {
                    window.Draw(wall);
                }
                //affiche tout les éléments dessiner au-dessus
                window.Display();

                //gère le déplacement de la voiture////////////////////////////////////////////////////////////////////////
                //lorsque la touche A est pressée
                if ((Keyboard.IsKeyPressed(Keyboard.Key.A)))
                {
                    //si le joueur à la cam lock, alors déplace la cam
                    if (x == xCar && y == yCar && camIslock == true)
                    {
                        x -= camSpeed;
                    }
                    //si le joueur n'est pas contre un mur
                    if (CheckCarPositionCompareToWall(xCar, yCar, carSizeX, carSizeY, walls.wallPositions))
                    {
                        xCar -= camSpeed;
                    }
                    //tourne la voiture dans le sens où elle va
                    car1Shape.Rotation = 270;
                    //change son point d'origine
                    car1Shape.Origin = new Vector2f(14, 16);
                    //change sa taille
                    car1Shape.Size = new Vector2f(28, 32);
                }
                //si la touche D est pressée
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.D)))
                {
                    //si le joueur à la cam lock, alors déplace la cam
                    if (x == xCar && y == yCar && camIslock == true)
                    {
                        x += camSpeed;
                    }
                    //si le joueur n'est pas contre un mur
                    xCar += camSpeed;
                    //tourne la voiture dans le sens où elle va
                    car1Shape.Rotation = 90;
                    //change son point d'origine
                    car1Shape.Origin = new Vector2f(14, 16);
                    //change sa taille
                    car1Shape.Size = new Vector2f(28, 32);
                }
                //si la touche W est pressée
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.W)))
                {
                    //si le joueur à la cam lock, alors déplace la cam
                    if (x == xCar && y == yCar && camIslock == true)
                    {
                        y -= camSpeed;
                    }
                    //si le joueur n'est pas contre un mur
                    yCar -= camSpeed;
                    //tourne la voiture dans le sens où elle va
                    car1Shape.Rotation = 0;
                    //change son point d'origine
                    car1Shape.Origin = new Vector2f(9, 24);
                    //change sa taille
                    car1Shape.Size = new Vector2f(18, 48);
                }
                //si la touche S est pressée
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.S)))
                {
                    //si le joueur à la cam lock, alors déplace la cam
                    if (x == xCar && y == yCar && camIslock == true)
                    {
                        y += camSpeed;
                    }
                    //si le joueur n'est pas contre un mur
                    yCar += camSpeed;
                    //tourne la voiture dans le sens où elle va
                    car1Shape.Rotation = 180;
                    //change son point d'origine
                    car1Shape.Origin = new Vector2f(9, 24);
                    //change sa taille
                    car1Shape.Size = new Vector2f(18, 48);
                }
                car1Shape.Position = new Vector2f(xCar, yCar);

                //gère le déplacement de la vue//////////////////////////////////////////////////////////////////
                
                //si la flèche de gauche est pressée et que la cam n'est pas plus loin que 30
                if ((Keyboard.IsKeyPressed(Keyboard.Key.Left)) && x > 30)
                {
                    //change la position de la cam
                    x -= camSpeed;
                    //delock la cam
                    camIslock = false;
                }
                //si la flèche de droite est pressée et que la cam n'est pas plus loin que 1900
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.Right)) && x < 1900)
                {
                    //change la position de la cam
                    x += camSpeed;
                    //delock la cam
                    camIslock = false;
                }                
                //si la flèche de haut est pressée et que la cam n'est pas plus loin que 20
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.Up)) && y > 20)
                {
                    //change la position de la cam
                    y -= camSpeed;
                    //delock la cam
                    camIslock = false;
                }                
                //si la flèche de bas est pressée et que la cam n'est pas plus loin que 1050
                else if ((Keyboard.IsKeyPressed(Keyboard.Key.Down)) && y < 1050)
                {
                    //change la position de la cam
                    y += camSpeed;
                    //delock la cam
                    camIslock = false;
                }
                //si la touche espace est pressée
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    //remet la cam sur la voiture et la lock sur la voiture
                    x = xCar;
                    y = yCar;
                    camIslock = true;
                }
                view.Center = new Vector2f(x, y);
            }
            //méthode qui arrete l'applicatino lorsque la fenetre est fermée
            void CloseWindow(object sender, EventArgs args)
            {
                Environment.Exit(0);
            }
            //vérifie la position de la voiture par rapport aux murs
            bool CheckCarPositionCompareToWall(int carPosX, int carPosY, int carXSize, int carYSize, List<float> wallPosition)
            {
                //TODO : détécter la collision entre la voiture et un mur (changer s'il faut dans wall pour la liste de position si besoin)
                int count = 0;
                /*foreach (float position in wallPosition)
                {
                    if (0=0) //TODO : rentrer la coondition de détéction
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    count += 2;
                }*/
                return true;
            }

        }
    }
}

