using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace SFML_Engine
{
    internal class StateHandler
    {
        GameState _state; //Contains the actual state
        GameState _nextState; //Contains the next state
        List<GameState> _allStates = new List<GameState>(); //Contains all the possible game state
        bool _isChanging; //Indicate if the actual state is going to change
        bool _loadNext;

        /// <summary>
        /// Add a new possible state
        /// </summary>
        /// <param name="states"> State(s) to add </param>
        public void AddState(params GameState[] states)
        {
            foreach (GameState s in states)
            {
                _allStates.Add(s);
            }
        }

        /// <summary>
        /// Update the actual state
        /// </summary>
        public void Update()
        {
            if (_isChanging)
            {
                _state = _nextState;
                if (_loadNext)
                {
                    _state.Load();
                    _loadNext = false;
                }
                _isChanging = false;
            }
        }

        /// <summary>
        /// Set the next state of the game
        /// </summary>
        /// <param name="nextStateName"> Next state name </param>
        public void SetNextState(string nextStateName)
        {
            _isChanging = true;
            foreach(GameState gs in _allStates)
            {
                if(gs.Name == nextStateName) { _nextState = gs; break; }
            }
        }

        /// <summary>
        /// Change the actual state of the game
        /// </summary>
        /// <param name="stateName"> New state name </param>
        public void ChangeActualState(string stateName)
        {
            foreach (GameState gs in _allStates)
            {
                if (gs.Name == stateName) { _state = gs; break; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadNextState()
        {
            _loadNext = true;
        }

        /// <summary>
        /// Get the actual state
        /// </summary>
        public GameState ActualState
        {
            get { return _state; }
        }

        /// <summary>
        /// Get all the stored states
        /// </summary>
        public List<GameState> AllStates
        {
            get { return _allStates; }
        }
    }
}
