///ETML
///Author : Kendy Song
///Date : 01.03.2022
///Summary : Manage window and count fps

using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.Timers;

namespace fps_counter
{
    class Window
    {
        //Attributes and properties
        private RenderWindow _window;
        private Clock _deltaTime = new Clock();                     //Method 1

        private int _fps = 0;                                       //Method 2
        private Timer _framerateTimer = new Timer();                //Method 2

        private Font _textFont = new Font("centuryGothic.ttf");     //Display
        private Text _fpsText;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">Width of the window</param>
        /// <param name="height">Height of the window</param>
        public Window(uint width, uint height)
        {
            //Init
            _window = new RenderWindow(new VideoMode(width, height), "fps-counter ");
            _window.SetFramerateLimit(60);
            _fpsText = new Text("0", _textFont);
            _fpsText.Position = new Vector2f(1100, 10);
            _framerateTimer.Elapsed += framerateTimerTick;
            _framerateTimer.Interval = 1000;
            _framerateTimer.Start();

            //Main loop
            while (_window.IsOpen)
            {
                //Method 1
                _fpsText.DisplayedString = Convert.ToString(1 / _deltaTime.ElapsedTime.AsSeconds());
                _deltaTime.Restart();

                //Method 2
                //_fps++;

                //Render
                _window.DispatchEvents();
                _window.Clear();
                _window.Draw(_fpsText);
                _window.Display();
            }         
        }

        /// <summary>
        /// Display framerate and reset counter (Method 2)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void framerateTimerTick(object sender, ElapsedEventArgs args)
        {          
            //_fpsText.DisplayedString = _fps.ToString();
            //_fps = 0;
        }
    }
}
