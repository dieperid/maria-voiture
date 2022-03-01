﻿///ETML
///Author : Kendy Song
///Date : 01.02.2022
///Summary : Manage window

using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;

namespace feature_bonus
{
    class Window
    {
        //Attributes and properties
        private string _title;
        private Clock _clock = new Clock();
        private RenderWindow _window;
        private List<Drawable> _drawableItems = new List<Drawable>();     
        private Random _random = new Random();
        private List<Bonus> _bonusItems = new List<Bonus>();

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

            //Init player
            Player player = new Player(new RectangleShape(new Vector2f(50, 50)), new Vector2f(width / 2, height / 2), 500);
            _drawableItems.Add(player.Shape);

            //Init bonus
            for (int i = 0; i < 10; i++)
            {
                Bonus bonus = new Bonus(new RectangleShape(new Vector2f(20, 20)), new Vector2f(_random.Next(0, (int)width), _random.Next(0, (int)height) - 20), _random.Next(0, 5), _random.Next());
                _drawableItems.Add(bonus.Shape);
                _bonusItems.Add(bonus);
            }        

            //Main loop
            while (_window.IsOpen)
            {
                //Get player input and display fps
                _window.SetTitle($"{title} {1/ _clock.ElapsedTime.AsSeconds()}");
                player.InputMove(_clock.ElapsedTime.AsSeconds());
                _clock.Restart();

                //Check collision between the bonus and the player
                for (int i = 0; i < _bonusItems.Count; i++)
                {
                    if (player.Collider.Intersects(_bonusItems[i].Collider))
                    {
                        //Give bonus to player if he dont have
                        if (!player.HaveBonus)
                        {
                            player.GetBonusObject(_bonusItems[i].Effect);
                            Console.WriteLine($"Player get {_bonusItems[i].Effect.ToString()}");
                        }

                        //Delete bonus
                        _drawableItems.Remove(_bonusItems[i].Shape);
                        _bonusItems.Remove(_bonusItems[i]);                                           
                    }
                }

                //Regenerate the bonus
                if (Keyboard.IsKeyPressed(Keyboard.Key.G))
                {
                    for(int i = 0; i < 10; i++)
                    {
                        Bonus bonus = new Bonus(new RectangleShape(new Vector2f(20, 20)), new Vector2f(_random.Next(0, (int)width), _random.Next(0, (int)height) - 20), _random.Next(0, 5), _random.Next());
                        _drawableItems.Add(bonus.Shape);
                        _bonusItems.Add(bonus);
                    }
                }

                //Render
                _window.DispatchEvents();
                _window.Clear();
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
