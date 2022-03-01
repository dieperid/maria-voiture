///ETML
///Author : Kendy Song
///Date : 08.02.2022
///Summary : Manage game display and update

using System;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Timers;
using System.Collections.Generic;
using InstilledBee.SFML.SimpleCollision;

namespace collision_detection
{
    /// <summary>
    /// Manage game display and update
    /// </summary>
    class GameManager
    {
        //Attributes and properties       
        private RenderWindow _window;
        private Clock _clock = new Clock();
        private List<Drawable> _drawableItems = new List<Drawable>();
        private List<Sprite> _spriteCollision = new List<Sprite>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="windowWidth">Width of the window</param>
        /// <param name="windowheight">Height of the window</param>
        /// <param name="title">Title of the widnow</param>
        public GameManager(uint windowWidth, uint windowHeight, string title)
        {
            //Init
            int fps = 0;
            int nbCollision = 0;
            Texture texture = new Texture(@"..\..\..\White.png");
            _window = new RenderWindow(new VideoMode(windowWidth, windowHeight), $"{title} {fps} FPS");
            _window.Closed += closeWindow;

            //Timer for count the the fps
            Timer tmrFramerate = new Timer();
            tmrFramerate.Interval = 1000;
            tmrFramerate.Elapsed += tmrFramerateTick;
            tmrFramerate.Start();

            //Create wall
            Sprite wall = new Sprite(texture, new IntRect(new Vector2i(0, 0), new Vector2i(100, 100)));
            wall.Position = new Vector2f(100, 20);
            wall.Rotation = 20f;
            _drawableItems.Add(wall);
            _spriteCollision.Add(wall);

            //Create wall
            Sprite wall1 = new Sprite(texture, new IntRect(new Vector2i(0, 0), new Vector2i(10, 10)));
            wall1.Position = new Vector2f(700, 400);
            _spriteCollision.Add(wall1);
            _drawableItems.Add(wall1);

            //Create player
            Player player = new Player(new Sprite(texture, new IntRect(new Vector2i(0, 0), new Vector2i(30, 70))), 200);
            _drawableItems.Add(player.Car);

            //Main loop
            while (_window.IsOpen)
            {
                player.InputMovement(_clock.ElapsedTime.AsSeconds());
                _clock.Restart();

                //Check collision
                for (int i = 0; i < _spriteCollision.Count; i++)
                    if (CollisionTester.PixelPerfectTest(player.Car, _spriteCollision[i], 0))
                        Console.WriteLine(nbCollision++);

                //Render and count fps number
                fps++;
                _window.Clear();
                _window.DispatchEvents();
                for (int i = 0; i < _drawableItems.Count; i++)
                    _window.Draw(_drawableItems[i]);
                _window.Display();
            }

            //Close the window
            void closeWindow(object sender, EventArgs args)
            {
                Environment.Exit(0);
            }

            //Timer for display framerate
            void tmrFramerateTick(object sender, ElapsedEventArgs args)
            {
                _window.SetTitle($"{title} {fps} FPS");
                fps = 0;
            }
        }
    }
}
