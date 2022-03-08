///ETML
///Auteur : Alexandre King
///Date : 25.01.22
///Description : classe pour les murs
using System;
using System.Collections.Generic;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace racetrack_implementation
{
    public partial class Wall
    {
        //variables
        public List<RectangleShape> walls = new List<RectangleShape>(); //liste de mur
        public List<float> wallPositions = new List<float>();           //liste des positions des murs
        /// <summary>
        /// constructeur 
        /// </summary>
        public Wall()                       
        {
            
        }
        /// <summary>
        /// crée tout les murs pour la première map
        /// </summary>
        public void CreateAllWallsMap1()
        {
            //outside walls            
            {
                CreateNewWall(10, 10, 190, 100);
                CreateNewWall(10, 20, 200, 80);
                CreateNewWall(10, 10, 210, 70);
                CreateNewWall(10, 20, 220, 50);
                CreateNewWall(10, 10, 230, 40);
                CreateNewWall(10, 10, 240, 30);
                CreateNewWall(10, 10, 250, 20);
                CreateNewWall(20, 10, 260, 10);
                CreateNewWall(190, 10, 280, 0);
                CreateNewWall(10, 10, 470, 10);
                CreateNewWall(20, 10, 480, 20);
                CreateNewWall(20, 10, 500, 30);
                CreateNewWall(40, 10, 520, 40);
                CreateNewWall(20, 10, 560, 50);
                CreateNewWall(30, 10, 580, 60);
                CreateNewWall(10, 10, 610, 70);
                CreateNewWall(30, 10, 620, 80);
                CreateNewWall(10, 10, 650, 90);
                CreateNewWall(20, 10, 660, 100);
                CreateNewWall(10, 10, 680, 110);
                CreateNewWall(20, 10, 690, 120);
                CreateNewWall(10, 10, 710, 130);
                CreateNewWall(20, 10, 720, 140);
                CreateNewWall(30, 10, 740, 150);
                CreateNewWall(30, 10, 770, 160);
                CreateNewWall(20, 10, 800, 170);
                CreateNewWall(40, 10, 820, 180);
                CreateNewWall(50, 10, 860, 190);
                CreateNewWall(50, 10, 910, 200);
                CreateNewWall(160, 10, 960, 210);
                CreateNewWall(30, 10, 1120, 200);
                CreateNewWall(20, 10, 1150, 190);
                CreateNewWall(10, 20, 1170, 170);
                CreateNewWall(10, 20, 1180, 150);
                CreateNewWall(10, 40, 1190, 110);
                CreateNewWall(10, 20, 1200, 90);
                CreateNewWall(10, 20, 1210, 70);
                CreateNewWall(10, 10, 1220, 60);
                CreateNewWall(10, 10, 1230, 50);
                CreateNewWall(10, 20, 1240, 30);
                CreateNewWall(20, 10, 1250, 20);
                CreateNewWall(10, 10, 1270, 10);
                CreateNewWall(300, 10, 1280, 0);
                CreateNewWall(10, 10, 1580, 10);
                CreateNewWall(10, 10, 1590, 20);
                CreateNewWall(10, 10, 1600, 30);
                CreateNewWall(10, 10, 1610, 40);
                CreateNewWall(10, 140, 1620, 50);
                CreateNewWall(10, 10, 1610, 190);
                CreateNewWall(20, 10, 1590, 200);
                CreateNewWall(10, 10, 1580, 210);
                CreateNewWall(20, 10, 1560, 220);
                CreateNewWall(10, 10, 1550, 230);
                CreateNewWall(10, 30, 1540, 240);
                CreateNewWall(10, 30, 1530, 270);
                CreateNewWall(10, 50, 1520, 300);
                CreateNewWall(20, 10, 1530, 350);
                CreateNewWall(10, 10, 1550, 340);
                CreateNewWall(20, 10, 1560, 330);
                CreateNewWall(10, 10, 1580, 320);
                CreateNewWall(10, 10, 1590, 310);
                CreateNewWall(10, 10, 1600, 300);
                CreateNewWall(10, 10, 1610, 290);
                CreateNewWall(10, 10, 1620, 280);
                CreateNewWall(10, 10, 1630, 270);
                CreateNewWall(10, 10, 1640, 260);
                CreateNewWall(10, 10, 1650, 250);
                CreateNewWall(10, 10, 1660, 240);
                CreateNewWall(10, 10, 1670, 230);
                CreateNewWall(10, 10, 1680, 220);
                CreateNewWall(10, 10, 1690, 210);
                CreateNewWall(20, 10, 1700, 200);
                CreateNewWall(100, 10, 1720, 190);
                CreateNewWall(20, 10, 1820, 200);
                CreateNewWall(10, 10, 1840, 210);
                CreateNewWall(10, 10, 1850, 220);
                CreateNewWall(10, 10, 1860, 230);
                CreateNewWall(10, 10, 1870, 240);
                CreateNewWall(10, 10, 1880, 250);
                CreateNewWall(10, 10, 1890, 260);
                CreateNewWall(10, 200, 1900, 270);
                CreateNewWall(10, 20, 1890, 470);
                CreateNewWall(10, 50, 1880, 490);
                CreateNewWall(10, 20, 1870, 540);
                CreateNewWall(10, 40, 1860, 560);
                CreateNewWall(10, 30, 1850, 600);
                CreateNewWall(10, 20, 1840, 630);
                CreateNewWall(10, 10, 1830, 650);
                CreateNewWall(10, 10, 1820, 660);
                CreateNewWall(10, 20, 1810, 670);
                CreateNewWall(10, 10, 1800, 690);
                CreateNewWall(10, 10, 1790, 700);
                CreateNewWall(10, 10, 1780, 710);
                CreateNewWall(30, 10, 1750, 720);
                CreateNewWall(20, 10, 1730, 730);
                CreateNewWall(10, 10, 1720, 740);
                CreateNewWall(50, 10, 1670, 750);
                CreateNewWall(40, 10, 1630, 760);
                CreateNewWall(110, 10, 1520, 770);
                CreateNewWall(110, 10, 1410, 780);
                CreateNewWall(50, 10, 1360, 770);
                CreateNewWall(20, 10, 1340, 760);
                CreateNewWall(20, 10, 1320, 750);
                CreateNewWall(20, 10, 1300, 740);
                CreateNewWall(20, 10, 1280, 730);
                CreateNewWall(20, 10, 1260, 720);
                CreateNewWall(20, 10, 1240, 710);
                CreateNewWall(10, 10, 1230, 700);
                CreateNewWall(10, 10, 1220, 690);
                CreateNewWall(20, 10, 1200, 680);
                CreateNewWall(70, 10, 1130, 670);
                CreateNewWall(10, 10, 1120, 680);
                CreateNewWall(10, 10, 1110, 690);
                CreateNewWall(20, 10, 1090, 700);
                CreateNewWall(20, 10, 1070, 710);
                CreateNewWall(10, 10, 1060, 720);
                CreateNewWall(20, 10, 1040, 730);
                CreateNewWall(20, 10, 1020, 740);
                CreateNewWall(280, 10, 740, 750);
                CreateNewWall(50, 10, 690, 740);
                CreateNewWall(20, 10, 670, 730);
                CreateNewWall(20, 10, 650, 720);
                CreateNewWall(10, 10, 640, 710);
                CreateNewWall(20, 10, 620, 700);
                CreateNewWall(40, 10, 580, 690);
                CreateNewWall(10, 10, 570, 700);
                CreateNewWall(10, 10, 560, 710);
                CreateNewWall(10, 90, 550, 720);
                CreateNewWall(10, 20, 560, 810);
                CreateNewWall(10, 10, 570, 830);
                CreateNewWall(10, 10, 580, 840);
                CreateNewWall(10, 10, 590, 850);
                CreateNewWall(10, 100, 600, 860);
                CreateNewWall(10, 40, 590, 960);
                CreateNewWall(10, 20, 580, 1000);
                CreateNewWall(20, 10, 560, 1020);
                CreateNewWall(20, 10, 540, 1030);
                CreateNewWall(50, 10, 490, 1040);
                CreateNewWall(100, 10, 390, 1050);
                CreateNewWall(50, 10, 340, 1040);
                CreateNewWall(50, 10, 290, 1030);
                CreateNewWall(40, 10, 250, 1020);
                CreateNewWall(10, 10, 240, 1010);
                CreateNewWall(20, 10, 220, 1000);
                CreateNewWall(20, 10, 200, 990);
                CreateNewWall(20, 10, 180, 980);
                CreateNewWall(10, 10, 170, 970);
                CreateNewWall(10, 10, 160, 960);
                CreateNewWall(10, 10, 150, 950);
                CreateNewWall(10, 10, 140, 940);
                CreateNewWall(10, 10, 130, 930);
                CreateNewWall(10, 10, 120, 920);
                CreateNewWall(10, 20, 110, 900);
                CreateNewWall(10, 10, 100, 890);
                CreateNewWall(10, 30, 90, 860);
                CreateNewWall(10, 410, 80, 450);
                CreateNewWall(10, 30, 90, 420);
                CreateNewWall(10, 20, 100, 400);
                CreateNewWall(10, 30, 110, 370);
                CreateNewWall(10, 20, 120, 350);
                CreateNewWall(10, 30, 130, 320);
                CreateNewWall(10, 30, 140, 290);
                CreateNewWall(10, 90, 150, 200);
                CreateNewWall(10, 30, 160, 170);
                CreateNewWall(10, 30, 170, 140);
                CreateNewWall(10, 30, 180, 110);
            }
            //inside Walls
            {
                CreateNewWall(10, 30, 290, 540);
                CreateNewWall(10, 40, 280, 570);
                CreateNewWall(10, 180, 270, 610);
                CreateNewWall(10, 10, 280, 790);
                CreateNewWall(10, 10, 290, 800);
                CreateNewWall(10, 10, 300, 810);
                CreateNewWall(10, 10, 310, 820);
                CreateNewWall(10, 10, 320, 830);
                CreateNewWall(10, 10, 330, 840);
                CreateNewWall(10, 10, 340, 850);
                CreateNewWall(10, 10, 350, 860);
                CreateNewWall(10, 10, 360, 870);
                CreateNewWall(10, 10, 370, 880);
                CreateNewWall(10, 10, 380, 890);
                CreateNewWall(10, 10, 390, 900);                
                CreateNewWall(20, 10, 400, 910);
                CreateNewWall(10, 20, 420, 890);
                CreateNewWall(10, 20, 410, 870);
                CreateNewWall(10, 20, 400, 850);
                CreateNewWall(10, 10, 390, 840);
                CreateNewWall(10, 40, 380, 800);
                CreateNewWall(10, 20, 370, 780);                
                CreateNewWall(10, 120, 360, 660);
                CreateNewWall(10, 20, 370, 640);
                CreateNewWall(10, 10, 380, 630);
                CreateNewWall(10, 10, 390, 620);
                CreateNewWall(10, 20, 400, 600);
                CreateNewWall(10, 10, 410, 590);
                CreateNewWall(10, 20, 420, 570);
                CreateNewWall(10, 10, 430, 560);
                CreateNewWall(10, 20, 440, 540);
                CreateNewWall(20, 10, 450, 530);
                CreateNewWall(20, 10, 470, 520);
                CreateNewWall(160, 10, 490, 510);
                CreateNewWall(30, 10, 650, 520);
                CreateNewWall(40, 10, 680, 530);
                CreateNewWall(30, 10, 720, 540);
                CreateNewWall(40, 10, 750, 550);
                CreateNewWall(30, 10, 790, 560);
                CreateNewWall(40, 10, 820, 570);
                CreateNewWall(120, 10, 860, 580);
                CreateNewWall(10, 10, 980, 570);
                CreateNewWall(10, 10, 990, 560);
                CreateNewWall(10, 10, 1000, 550);
                CreateNewWall(20, 10, 1010, 540);
                CreateNewWall(10, 10, 1030, 530);
                CreateNewWall(10, 10, 1040, 520);
                CreateNewWall(20, 10, 1050, 510);
                CreateNewWall(10, 10, 1070, 500);
                CreateNewWall(30, 10, 1080, 490);
                CreateNewWall(100, 10, 1110, 480);
                CreateNewWall(20, 10, 1210, 490);
                CreateNewWall(20, 10, 1230, 500);
                CreateNewWall(10, 10, 1250, 510);
                CreateNewWall(40, 10, 1260, 520);
                CreateNewWall(10, 10, 1300, 530);
                CreateNewWall(20, 10, 1310, 540);
                CreateNewWall(20, 10, 1330, 550);
                CreateNewWall(10, 10, 1350, 560);
                CreateNewWall(20, 10, 1360, 570);
                CreateNewWall(20, 10, 1380, 580);
                CreateNewWall(10, 10, 1400, 590);
                CreateNewWall(40, 10, 1410, 600);
                CreateNewWall(90, 10, 1450, 610);
                CreateNewWall(70, 10, 1540, 600);
                CreateNewWall(10, 10, 1610, 590);
                CreateNewWall(20, 10, 1620, 580);
                CreateNewWall(20, 10, 1640, 570);
                CreateNewWall(10, 10, 1660, 560);
                CreateNewWall(10, 20, 1670, 540);
                CreateNewWall(10, 10, 1680, 530);
                CreateNewWall(10, 20, 1690, 510);
                CreateNewWall(10, 10, 1700, 500);
                CreateNewWall(10, 20, 1710, 480);
                CreateNewWall(10, 40, 1720, 440);
                CreateNewWall(10, 10, 1730, 430);
                CreateNewWall(10, 10, 1740, 420);
                CreateNewWall(10, 20, 1750, 400);
                CreateNewWall(10, 40, 1760, 360);
                CreateNewWall(10, 10, 1770, 350);
                CreateNewWall(10, 10, 1710, 460);
                CreateNewWall(10, 10, 1700, 470);
                CreateNewWall(10, 10, 1690, 480);
                CreateNewWall(40, 10, 1650, 490);
                CreateNewWall(40, 10, 1610, 500);
                CreateNewWall(70, 10, 1540, 510);
                CreateNewWall(10, 10, 1530, 500);
                CreateNewWall(30, 10, 1420, 480);
                CreateNewWall(40, 10, 1380, 470);
                CreateNewWall(10, 10, 1370, 460);
                CreateNewWall(10, 30, 1360, 430);
                CreateNewWall(10, 20, 1350, 410);
                CreateNewWall(10, 10, 1340, 400);
                CreateNewWall(10, 50, 1330, 350);
                CreateNewWall(10, 50, 1320, 300);
                CreateNewWall(10, 20, 1330, 280);
                CreateNewWall(10, 10, 1340, 270);
                CreateNewWall(10, 20, 1350, 250);
                CreateNewWall(10, 20, 1360, 230);
                CreateNewWall(10, 30, 1370, 200);
                CreateNewWall(10, 30, 1380, 170);
                CreateNewWall(10, 40, 1390, 130);
                CreateNewWall(10, 10, 1400, 120);
                CreateNewWall(20, 10, 1410, 110);
                CreateNewWall(10, 20, 1430, 120);
                CreateNewWall(10, 10, 1420, 140);
                CreateNewWall(10, 10, 1410, 150);
                CreateNewWall(10, 10, 1400, 160);
                CreateNewWall(10, 10, 1310, 310);
                CreateNewWall(20, 10, 1290, 320);
                CreateNewWall(10, 10, 1280, 330);
                CreateNewWall(10, 30, 1270, 340);
                CreateNewWall(10, 10, 1160, 390);
                CreateNewWall(250, 10, 910, 400);
                CreateNewWall(60, 10, 850, 390);
                CreateNewWall(30, 10, 820, 380);
                CreateNewWall(30, 10, 790, 370);
                CreateNewWall(30, 10, 760, 360);
                CreateNewWall(30, 10, 730, 350);
                CreateNewWall(40, 10, 690, 340);
                CreateNewWall(30, 10, 660, 330);
                CreateNewWall(20, 10, 640, 320);
                CreateNewWall(10, 10, 630, 310);
                CreateNewWall(20, 10, 610, 300);
                CreateNewWall(20, 10, 590, 290);
                CreateNewWall(20, 10, 570, 280);
                CreateNewWall(30, 10, 540, 270);
                CreateNewWall(30, 10, 510, 260);
                CreateNewWall(20, 10, 490, 250);
                CreateNewWall(40, 10, 450, 240);
                CreateNewWall(10, 10, 440, 230);
                CreateNewWall(20, 10, 420, 220);
                CreateNewWall(20, 10, 400, 210);
                CreateNewWall(10, 10, 390, 200);
                CreateNewWall(10, 10, 380, 190);
                CreateNewWall(10, 10, 370, 200);
                CreateNewWall(10, 30, 360, 210);
                CreateNewWall(10, 40, 350, 240);
                CreateNewWall(10, 60, 340, 280);
                CreateNewWall(10, 40, 330, 340);
                CreateNewWall(10, 20, 320, 380);
                CreateNewWall(10, 20, 310, 400);
                CreateNewWall(10, 120, 300, 420);
            }
            //secret path walls
            {
                CreateNewWall(10, 20, 1170, 390);
                for (int i = 0; i < 9; i++)
                {
                    CreateNewWall(10, 10, 1180+i*10, 410 + i * 10);
                }
                CreateNewWall(20, 10, 1270, 500);
                CreateNewWall(10, 10, 1290, 510);
                CreateNewWall(10, 10, 1300, 520);

            }

        }
        /// <summary>
        /// crée un nouveau mur
        /// </summary>
        /// <param name="sizeX">largeur du mur</param>
        /// <param name="sizeY">hauteur du mur</param>
        /// <param name="posX">position x du mur</param>
        /// <param name="posY">position y du mur</param>
        public void CreateNewWall(float sizeX, float sizeY, float posX, float posY)
        {
            //crée un nouveau rectangle et lui donne sa taille
            RectangleShape newWall = new RectangleShape(new Vector2f(sizeX, sizeY));
            //lui donne sa position
            newWall.Position = new Vector2f(posX, posY);
            //lui donne une couleur (à enlever une fois tout les murs finis)
            newWall.FillColor = Color.Magenta;                        
            //ajoute le mur à la liste de mur
            this.walls.Add(newWall);
            //ajoute la position X et Y à la liste de position
            wallPositions.Add(posX);
            wallPositions.Add(posY);
        }
    }
    
}
