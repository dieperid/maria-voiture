using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace game_lobby
{
    internal class WidgetHandler
    {
        //List<Widget> _widgets = new List<Widget>(); //List of widget
        InputHandler _inputHandler; // Handles input
        GameState _actualState;
        Font _font;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ih"> Input handler </param>
        public WidgetHandler(InputHandler ih)
        {
            _inputHandler = ih;
        }

        /// <summary>
        /// Add a button
        /// </summary>
        public Button CreateButton()
        {
            Button btn = new Button(_font, _inputHandler);
            _actualState.Widgets.Add(btn);
            return btn;
        }

        /// <summary>
        /// Add a slider
        /// </summary>
        /// <param name="txt"> Slider's text </param>
        public Slider CreateSlider(string txt)
        {
            Slider slider = new Slider(txt, _font, _inputHandler);
            _actualState.Widgets.Add(slider);
            return slider;
        }

        /// <summary>
        /// Add a label
        /// </summary>
        /// <returns> The Created label </returns>
        public Label CreateLabel()
        {
            Label lbl = new Label(_font, _inputHandler);
            _actualState.Widgets.Add(lbl);
            return lbl;
        }

        /// <summary>
        /// Update all widgets
        /// </summary>
        /// <param name="dt"> Delta time </param>
        public void Update(float dt)
        {
            foreach (Widget widget in _actualState.Widgets)
            {
                widget.Update(dt);
            }
        }

        /// <summary>
        /// Render all widget
        /// </summary>
        /// <param name="w"> Used window </param>
        public void Render(RenderWindow w)
        {
            foreach (Widget widget in _actualState.Widgets)
            {
                widget.Render(w);
            }
        }

        public void StateUpdate(GameState state)
        {
            _actualState = state;
        }

        /// <summary>
        /// Get/Set font
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        /// <summary>
        /// et/Set State
        /// </summary>
        public GameState GameState
        {
            get { return _actualState; }
            set { _actualState = value; }
        }
    }
}
