using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace SFML_Engine
{
    abstract class GameState
    {
        private string _name; //Name of this instance
        protected StateHandler _stateHandler;
        protected AssetManager _assetManager;
        protected InputHandler _inputHandler;
        protected GameClock _gameClock;
        protected RenderWindow _window;
        protected WidgetHandler _widgetHandler;
        protected Color _clearColor; //Background color
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"> Name of the instance </param>
        /// <param name="sh"> State handler </param>
        /// <param name="am"> Asset manager </param>
        /// <param name="ih"> Input handler </param>
        /// <param name="gc"> game clock </param>
        /// <param name="w"> Render window </param>
        /// <param name="wh"> Widget handler </param>
        public GameState(string name, StateHandler sh, AssetManager am, InputHandler ih, GameClock gc, RenderWindow w, WidgetHandler wh)
        {
            _name = name;
            _stateHandler = sh;
            _assetManager = am;
            _inputHandler = ih;
            _gameClock = gc;
            _window = w;
            _widgetHandler = wh;
        }
        /// <summary>
        /// Loads all elements necessary
        /// </summary>
        public abstract void Load();
        /// <summary>
        /// Update state
        /// </summary>
        /// <param name="dt"> Delta time </param>
        public abstract void Update();
        /// <summary>
        /// Render state
        /// </summary>
        /// <param name="w"> Used window </param>
        public abstract void Render();
        /// <summary>
        /// Get the name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// Get the clear color
        /// </summary>
        public Color ClearColor
        {
            get { return _clearColor;}
        }
    }
}
