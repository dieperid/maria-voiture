using System;
using System.Collections.Generic;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace racetrack_implementation
{
    public class Wall
    {
        public List<RectangleShape> walls = new List<RectangleShape>();
        public Wall()
        {
            
        }
        public void CreateAllWallsMap1()
        {
            CreateNewWall(10,10,190,100);
            CreateNewWall(10,20,200,80);
            CreateNewWall(10,10,210,70);
            CreateNewWall(10, 20, 220, 50);
            CreateNewWall(10, 10, 230, 40);
            CreateNewWall(10, 10, 240, 30);
            CreateNewWall(10, 10, 250, 20);
            CreateNewWall(20, 10, 260, 10);            
            CreateNewWall(190, 10, 280,0);
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
            //
            CreateNewWall(30, 10, 1750, 720);
            CreateNewWall(20, 10, 1730, 730);
            CreateNewWall(10, 10, 1720, 740);
            CreateNewWall(50, 10, 1670, 750);
            CreateNewWall(50, 10, 1670, 750);



        }
        public void CreateNewWall(float sizeX, float sizeY, float posX, float posY)
        {
            RectangleShape newWall = new RectangleShape(new Vector2f(sizeX, sizeY));
            newWall.Position = new Vector2f(posX, posY);
            newWall.FillColor = Color.Magenta;
            this.walls.Add(newWall);
        }
    }
    
}
