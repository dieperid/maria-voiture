using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace mode_choice
{
    class ModeChoice
    {
        IntPtr handler = new IntPtr();
        RenderWindow _window;

        RectangleShape _background;

        Button _btnNormal;

        public ModeChoice(uint w, uint h, string title)
        {
            _window = new RenderWindow(new VideoMode(w, h), title, Styles.Fullscreen);

            // Création du rectangle contenant le background
            _background = new RectangleShape(new Vector2f(_window.Size.X, _window.Size.Y));

            _background.Texture = new Texture(Resource1.background);

            //Création du bouton multijoueur
            _btnNormal = new Button(new Font("../../../../../Font/pixelart.ttf"), new RenderWindow(handler));
            _btnNormal.Texture = new Texture(Resource1.btnNormal); // Image 456 x 462
            _btnNormal.Position = new Vector2f(158, 450);
            _btnNormal.Size = new Vector2f(456, 462);
            _btnNormal.ClickedEvent += btnMultiplayerClick;
            _btnNormal.Over += btnOver;
            _btnNormal.NotOver += btnNotOver;

        }
        public void Run()
        {
            _window.Closed += WinClose;

            //Game loop
            while (_window.IsOpen)
            {
                //Dispatch windows events
                _window.DispatchEvents();

                _window.Draw(_background);

                //Display new image
                _window.Display();
            }
        }

        void WinClose(Object obj, EventArgs e)
        {
            (obj as RenderWindow).Close();
        }

        #region[Méthode lorsque on appuie sur un bouton]

        /// <summary>
        /// Méthode qui vas etre effectuer lorsqu'on appuie sur le bouton Multijoueur
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">EventArgs</param>
        public void btnMultiplayerClick(object sender, EventArgs args)
        {
            //_stateHandler.SetNextState(typeof(MenuMulti).Name);
        }

        public void btnOver(object sender, EventArgs args)
        {
            Button btn = sender as Button;
            btn.Color = Color.Black;
        }

        public void btnNotOver(object sender, EventArgs args)
        {
            Button btn = sender as Button;
            btn.Color = Color.White;
        }

        #endregion



    }
}
