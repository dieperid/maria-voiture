///ETML
///Author : Kendy Song
///Date : 01.02.2022
///Summary : Manage window

using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;

namespace feature_outside
{
    class Window
    {
        //Attributes and properties
        private string _title;
        private RenderWindow _window;
        private Clock _clock = new Clock();

        //Game managament
        private List<Drawable> _drawableItems = new List<Drawable>();
        private List<Grass> _grassMap = new List<Grass>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">Width of the window</param>
        /// <param name="height">Height of the window</param>
        /// <param name="title">Title of the window</param>
        public Window(uint width, uint height, string title)
        {
            //Init
            _window = new RenderWindow(new VideoMode(width, height), title);
            _window.Closed += Close;
            _title = title;
      
            //Init map
            _grassMap.Add(new Grass(new RectangleShape(new Vector2f(100, 720)), new Vector2f(0, 0)));
            _drawableItems.Add(_grassMap[_grassMap.Count - 1].Shape);

            _grassMap.Add(new Grass(new RectangleShape(new Vector2f(100, 520)), new Vector2f(250, 200)));
            _drawableItems.Add(_grassMap[_grassMap.Count - 1].Shape);

            _grassMap.Add(new Grass(new RectangleShape(new Vector2f(1280, 100)), new Vector2f(100, 0)));
            _drawableItems.Add(_grassMap[_grassMap.Count - 1].Shape);


            _grassMap.Add(new Grass(new RectangleShape(new Vector2f(1030, 100)), new Vector2f(300, 200)));
            _drawableItems.Add(_grassMap[_grassMap.Count - 1].Shape);

            //Init player
            Player player = new Player(new RectangleShape(new Vector2f(50, 50)), new Vector2f(150, 600), 500);
            _drawableItems.Add(player.Shape);

            //Main loop
            while (_window.IsOpen)
            {
                //Get player input and display fps
                _window.SetTitle($"{title} {1 / _clock.ElapsedTime.AsSeconds()}");
                player.InputMove(_clock.ElapsedTime.AsSeconds());
                _clock.Restart();

                //Check collision with the grass and the player
                player.IsSlow = false;
                for (int i = 0; i < _grassMap.Count; i++)
                {
                    if (player.Collider.Intersects(_grassMap[i].Collider))
                    {
                        player.IsSlow = true;
                        if (player.Speed > 40)                        
                            player.Speed -= 1;
                        Console.WriteLine(player.Speed);
                    }                   
                }

                //Reset the speed of the player
                if (!player.IsSlow)
                    if (player.Speed < player.BaseSpeed)                    
                        player.Speed++;                                                      

                //Render
                _window.DispatchEvents();
                _window.Clear(new Color(50, 50, 50));
                for (int i = 0; i < _drawableItems.Count; i++)
                    _window.Draw(_drawableItems[i]);
                _window.Display();
            }
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender">unused</param>
        /// <param name="args">unused</param>
        public void Close(object sender, EventArgs args)
        {
            Environment.Exit(0);
        }
    }
}
