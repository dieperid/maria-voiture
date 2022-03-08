using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MenuOptions
{
    class Window
    {
        /// <summary>
        /// 
        /// </summary>
        private const uint _WINDOW_WIDTH = 1920;
        /// <summary>
        /// 
        /// </summary>
        private const uint _WINDOW_HEIGHT = 1080;
        /// <summary>
        /// Settings pour la window
        /// </summary>
        private ContextSettings _settings;

        

        private List<Drawable> _listDrawableItems = new List<Drawable>();

        public List<Drawable> ListDrawableItems
        {
            get { return _listDrawableItems; }
            set { _listDrawableItems = value; }
        }

        public Window()
        {
            _settings = new ContextSettings { AntialiasingLevel = 8 };
            RenderWindow window = new RenderWindow(new VideoMode(_WINDOW_WIDTH, _WINDOW_HEIGHT), "Window", Styles.Fullscreen, _settings);
            
            MenuOption option = new MenuOption(_WINDOW_WIDTH, _WINDOW_HEIGHT);

            _listDrawableItems.Add(option.TitleShape);
            _listDrawableItems.Add(option.SoundShape);
            _listDrawableItems.Add(option.TextOnShape);
            _listDrawableItems.Add(option.TextOffShape);
            _listDrawableItems.Add(option.SliderSoundShape);


            while (window.IsOpen)
            {
                window.Clear(Color.Cyan);
               
                foreach(var item in _listDrawableItems)
                {
                    window.Draw(item);
                }

                window.Display();

                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    window.Close();
                }
            }
        }
    }
}
