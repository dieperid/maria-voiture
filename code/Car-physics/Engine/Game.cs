using System;
using System.Collections.Generic;
using System.Reflection;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace SFML_Engine
{
    internal class Game
    {
        StateHandler _stateHandler;
        AssetManager _assetManager;
        InputHandler _inputHandler;
        GameClock _gameClock;
        RenderWindow _window;
        WidgetHandler _widgetHandler;

        public Game(uint w, uint h, string title)
        {
            _window = new RenderWindow(new VideoMode(w, h), title, Styles.Fullscreen);
            _stateHandler = new StateHandler();
            _assetManager = new AssetManager();
            _inputHandler = new InputHandler(_window);
            _widgetHandler = new WidgetHandler(_inputHandler);
            _gameClock = new GameClock();
            _stateHandler.AddState(LoadGameStates());
            if (_stateHandler.AllStates.Count > 0)
            {
                _stateHandler.ChangeActualState(_stateHandler.AllStates[0].Name);
            }
        }

        /// <summary>
        /// Loads all the game state created by the user
        /// </summary>
        GameState[] LoadGameStates()
        {
            //All game state to return
            List<GameState> toReturn = new List<GameState>();

            //Get all types in the current executing assembly
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            //Instantiate all sub class of game state
            foreach (Type t in types)
            {
                if (t.IsSubclassOf(typeof(GameState)))
                {
                    toReturn.Add(Activator.CreateInstance(t, t.Name, _stateHandler, _assetManager, _inputHandler, _gameClock, _window, _widgetHandler) as GameState);
                }
            }

            if(toReturn.Count == 0)
            {
                LogHandler.GetInstance().AddLog("[GAME][LOADGAMESTATE-ERROR] No game state found");
            }

            return toReturn.ToArray();
        }

        public void Run()
        {
            //End program if no game state
            if (_stateHandler.ActualState == null)
            {
                LogHandler.GetInstance().AddLog("[GAME][RUN-ERROR] No game state");
                return;
            }

            //Loads games states
            foreach(GameState gs in _stateHandler.AllStates)
            {
                gs.Load();
            }

            //Subscribe to windows event
            _window.Closed += WinClose;

            //Game loop
            while (_window.IsOpen)
            {
                //Reset the frame time
                _gameClock.ResetFrame();

                //Dispatch windows events
                _window.DispatchEvents();

                //Update keyboard's keys and mouse's buttons states 
                _inputHandler.Update();

                //Update widgets
                _widgetHandler.Update(_gameClock.ElapsedFrame());

                //Update the actual game state
                _stateHandler.ActualState.Update();

                //Clear last image
                _window.Clear(_stateHandler.ActualState.ClearColor);

                //Render the actual game state
                _stateHandler.ActualState.Render();

                //Render widget
                _widgetHandler.Render(_window);

                //Display new image
                _window.Display();

                //Update the state handler
                _stateHandler.Update();
            }
        }

        void WinClose(Object obj, EventArgs e)
        {
            (obj as RenderWindow).Close();
        }
    }
}
