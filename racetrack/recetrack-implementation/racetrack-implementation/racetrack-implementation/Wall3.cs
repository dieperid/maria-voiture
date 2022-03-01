using System;
using System.Collections.Generic;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace racetrack_implementation
{
    public partial class Wall3
    {
        public List<RectangleShape> walls = new List<RectangleShape>();
        public Wall3()
        {

        }
        public void CreateAllWallsMap3()
        {
            CreateNewWall(250, 10, 370, 490);
            CreateNewWall(40, 10, 610, 480);
            CreateNewWall(20, 10, 640, 470);
            CreateNewWall(60, 10, 660, 460);
            CreateNewWall(40, 10, 720, 470);
            CreateNewWall(30, 10, 760, 480);
            CreateNewWall(20, 10, 790, 490);
            CreateNewWall(10, 10, 810, 500);
            CreateNewWall(10, 10, 820, 510);
            CreateNewWall(10, 10, 830, 520);
            CreateNewWall(10, 20, 840, 530);
            CreateNewWall(10, 10, 850, 550);
            CreateNewWall(10, 10, 860, 560);
            CreateNewWall(10, 10, 870, 570);
            CreateNewWall(10, 30, 880, 580);
            CreateNewWall(10, 60, 890, 610);
            CreateNewWall(10, 10, 880, 670);
            CreateNewWall(10, 10, 870, 680);
            CreateNewWall(10, 10, 860, 690);
            CreateNewWall(10, 10, 850, 700);
            CreateNewWall(10, 10, 840, 710);
            CreateNewWall(20, 10, 820, 720);
            CreateNewWall(20, 10, 800, 730);
            CreateNewWall(10, 10, 790, 740);
            CreateNewWall(10, 10, 780, 750);
            CreateNewWall(30, 10, 750, 760);
            CreateNewWall(20, 10, 730, 770);
            CreateNewWall(10, 10, 720, 780);
            CreateNewWall(30, 10, 690, 790);
            CreateNewWall(30, 10, 660, 800);
            CreateNewWall(30, 10, 630, 810);
            CreateNewWall(30, 10, 630, 810);
            CreateNewWall(60, 10, 570, 820);
            CreateNewWall(140, 10, 430, 830);
            CreateNewWall(40, 10, 390, 840);
            CreateNewWall(10, 10, 380, 850);
            CreateNewWall(10, 10, 390, 860);
            CreateNewWall(10, 30, 400, 870);
            CreateNewWall(60, 10, 410, 900);
            CreateNewWall(70, 10, 470, 910);
            CreateNewWall(20, 10, 540, 900);
            CreateNewWall(10, 10, 560, 890);
            CreateNewWall(30, 10, 570, 880);
            CreateNewWall(10, 10, 600, 870);
            CreateNewWall(20, 10, 610, 860);
            CreateNewWall(30, 10, 630, 850);
            CreateNewWall(20, 10, 660, 840);
            CreateNewWall(30, 10, 680, 830);
            CreateNewWall(20, 10, 710, 820);
            CreateNewWall(20, 10, 730, 810);
            CreateNewWall(50, 10, 750, 800);
            CreateNewWall(140, 10, 800, 790);
            CreateNewWall(20, 10, 940, 800);
            CreateNewWall(20, 10, 960, 810);
            CreateNewWall(10, 10, 980, 820);
            CreateNewWall(10, 10, 990, 830);
            CreateNewWall(10, 10, 1000, 840);
            CreateNewWall(10, 10, 1010, 850);
            CreateNewWall(10, 10, 1020, 860);
            CreateNewWall(10, 10, 1030, 870);
            CreateNewWall(10, 10, 1040, 880);
            CreateNewWall(10, 10, 1050, 890);
            CreateNewWall(10, 10, 1060, 900);
            CreateNewWall(20, 20, 1070, 910);
            CreateNewWall(20, 10, 1080, 930);
            CreateNewWall(10, 10, 1100, 940);
            CreateNewWall(10, 10, 1110, 950);
            CreateNewWall(20, 10, 1120, 960);
            CreateNewWall(20, 10, 1120, 960);
            CreateNewWall(10, 40, 1070, 870);
            CreateNewWall(10, 70, 1060, 800);
            CreateNewWall(10, 10, 1070, 790);
            CreateNewWall(10, 20, 1080, 770);
            CreateNewWall(10, 10, 1090, 760);
            CreateNewWall(10, 10, 1100, 750);
            CreateNewWall(10, 10, 1110, 740);
            CreateNewWall(30, 10, 1120, 730);
            CreateNewWall(50, 10, 1150, 720);
            CreateNewWall(10, 10, 1200, 710);
            CreateNewWall(40, 10, 1210, 700);
            CreateNewWall(40, 10, 1250, 690);
            CreateNewWall(60, 10, 1290, 680);
            CreateNewWall(10, 40, 1340, 640);
            CreateNewWall(10, 20, 1330, 620);
            CreateNewWall(10, 30, 1320, 590);
            CreateNewWall(10, 20, 1310, 570);
            CreateNewWall(10, 20, 1300, 550);
            CreateNewWall(20, 10, 1280, 550);
            CreateNewWall(30, 10, 1250, 540);
            CreateNewWall(10, 10, 1240, 550);
            CreateNewWall(40, 10, 1200, 560);
            CreateNewWall(30, 10, 1170, 570);
            CreateNewWall(60, 10, 1110, 580);
            CreateNewWall(150, 10, 960, 590);
            CreateNewWall(20, 10, 940, 580);
            CreateNewWall(20, 10, 920, 570);
            CreateNewWall(20, 10, 900, 560);
            CreateNewWall(10, 10, 890, 550);
            CreateNewWall(10, 10, 880, 540);
            CreateNewWall(10, 10, 870, 530);
            CreateNewWall(10, 30, 860, 500);
            CreateNewWall(10, 150, 850, 350);
            CreateNewWall(10, 30, 860, 320);
            CreateNewWall(10, 10, 870, 310);
            CreateNewWall(10, 10, 880, 300);
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
