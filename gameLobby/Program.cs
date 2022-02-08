using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace gameLobby
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            const int WINDOWHEIGHT = 1080;
            const int WINDOWWIDTH = 1920;

            List<Drawable> drawables = new List<Drawable>();            //List of drawable
            List<Player> players = new List<Player>();

            //Create window
            RenderWindow window = new RenderWindow(new VideoMode(WINDOWWIDTH, WINDOWHEIGHT), "Game lobby");

            //Create wait text
            RectangleShape waitContainer = new RectangleShape(new Vector2f(1000, 100));
            waitContainer.Position = new Vector2f(WINDOWWIDTH / 2 - (waitContainer.Size.X / 2), 20);
            Text waitText = new Text("EN ATTENTE DE L'HOTE", new Font("../../../fonts/pixelart.ttf"), 50);
            waitText.Position = new Vector2f(waitContainer.Position.X, waitContainer.Position.Y);

            drawables.Add(waitContainer);
            const int SPACE = 10;
            int count = 1;

            //Create players
            for (int i = 0; i < 3; i++)
            {

                for(int s = 0; s < 2; s++)
                {
                    //Create a player
                    Player player = new Player($"Player {count}", new RectangleShape(new Vector2f(800, 200)));
                    //Set the parameters of the rectangle of players
                    player.Rectangle.Position = new Vector2f(s * (player.Rectangle.Size.X + SPACE) + WINDOWWIDTH / 2 - player.Rectangle.Size.X, i * (player.Rectangle.Size.Y + SPACE) + waitContainer.Size.Y * 2);
                    player.Rectangle.FillColor = new Color(153, 204, 255);
                    player.Rectangle.OutlineThickness = SPACE;
                    player.Rectangle.OutlineColor = Color.Black;
                    //Set the parameters of the text of players
                    player.Text.FillColor = Color.Black;
                    player.Text.Position = new Vector2f(s * (player.Rectangle.Size.X + SPACE) + WINDOWWIDTH / 2 - player.Rectangle.Size.X + SPACE * 10, i * (player.Rectangle.Size.Y + SPACE) + waitContainer.Size.Y * 2 + player.Rectangle.Size.Y / 3);
                    players.Add(player);

                    count++;
                }
            }

            //Event close
            window.Closed += Close;

            while (window.IsOpen)
            {
                //Events of window
                window.DispatchEvents();
                //Clear window
                window.Clear(new Color(230, 230, 230));

                //Draw elements
                foreach (Drawable draw in drawables)
                {
                    window.Draw(draw);
                }

                foreach(Player player in players)
                {
                    window.Draw(player.Rectangle);
                    window.Draw(player.Text);
                }

                //Display window
                window.Display();
            }


            //Close event fonction
            void Close(object sender, EventArgs args)
            {
                Environment.Exit(0);
            }

        }
    }
}
