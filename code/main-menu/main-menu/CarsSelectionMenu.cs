using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace main_menu
{
    class CarsSelectionMenu : GameState
    {
        /// <summary>
        /// Initialisation du bouton quit
        /// </summary>
        Button btnQuit;

        /// <summary>
        /// Initialisation de la renderwindow
        /// </summary>
        RenderWindow _w;

        Cars car1;

        /// <summary>
        /// Initialisation d'un rectangleshape qui vas contenir le background du menu
        /// </summary>
        RectangleShape _background;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Nom</param>
        /// <param name="sh">StateHandler</param>
        /// <param name="am">AssetManager</param>
        /// <param name="ih">InputHandler</param>
        /// <param name="gc">GameClock</param>
        /// <param name="w">RenderWindow</param>
        /// <param name="wh">WidgetHandler</param>
        public CarsSelectionMenu(string name, StateHandler sh, AssetManager am, InputHandler ih, GameClock gc, RenderWindow w, WidgetHandler wh) : base(name, sh, am, ih, gc, w, wh)
        {
            _w = w;
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

        /// <summary>
        /// Méthode qui vas etre effectuer lorsqu'on appuie sur le bouton Solo
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">EventArgs</param>
        public void btnSoloClick(object sender, EventArgs args)
        {
            //_stateHandler.SetNextState(typeof(MenuSolo).Name);
        }
        /// <summary>
        /// Méthode qui vas etre effectuer lorsqu'on appuie sur le bouton Option
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">EventArgs</param>
        public void btnOptionClick(object sender, EventArgs args)
        {
            //_stateHandler.SetNextState(typeof(MenuOption).Name);
        }
        /// <summary>
        /// Méthode qui vas etre effectuer lorsqu'on appuie sur le bouton Quit
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">EventArgs</param>
        public void btnQuitClick(object sender, EventArgs args)
        {
            _stateHandler.SetNextState(typeof(MainMenu).Name);
        }

        #endregion

        /// <summary>
        /// Méthode qui vas être lancer lors du lancement
        /// </summary>
        public override void Load()
        {
            // Création du rectangle contenant le background
            _background = new RectangleShape(new Vector2f(_window.Size.X, _window.Size.Y));

            _background.Texture = new Texture(Resource1.background);

            // Création du bouton quit
            btnQuit = _widgetHandler.CreateButton();
            btnQuit.Texture = new Texture(Resource1.btnQuit); // Image 576 x 100
            btnQuit.Position = new Vector2f(1118, 950);
            btnQuit.Size = new Vector2f(576, 100);
            btnQuit.ClickedEvent += btnQuitClick;
            btnQuit.Over += btnOver;
            btnQuit.NotOver += btnNotOver;

            car1 = new Cars(_w, new Texture(Resource1.background), new Vector2f(20, 20));
            car1.Load();
        }

        /// <summary>
        /// Méthode ou on vas intégrer les updates
        /// </summary>
        public override void Update()
        {
            car1.Update();
        }

        /// <summary>
        /// Méthode ou on vas vouloir afficher quelque chose
        /// </summary>
        public override void Render()
        {
            // Affichage du background toujour en premier
            _w.Draw(_background);
            // Affichage des autres inputs
            car1.Render(_widgetHandler);
        }
    }

    class Cars
    {

        private bool _choose = false;

        private User _user;

        private Texture _image;

        private Vector2f _position = new Vector2f(20,20);

        private RenderWindow _w;

        Button btnChoose;

        Label lblName;

        public Cars(RenderWindow w,Texture image, Vector2f position)
        {
            _position = position;
            _image = image;
            _w = w;
        }

        public void btnChooseClick(object sender,EventArgs eventArgs)
        {
            _choose = true;
        }

        public void Load()
        {
            User user1 = new User();
            _user = user1;
            _user.Name = "Benjamin";
        }

        public void Update()
        {
            if(_choose == true)
            {
                // met user name dans le btnchoose et lock
                btnChoose.Color = Color.Black;
            }
        }

        public void Render(WidgetHandler wh)
        {
            RectangleShape rect = new RectangleShape(new Vector2f(600,500));
            
            rect.Position = _position;
            rect.FillColor = Color.White;
            rect.OutlineColor = Color.Black;

            /* = new Button(new Vector2f(580, 50));*/

            // Création du bouton choose
            btnChoose = wh.CreateButton();
            btnChoose.Texture = new Texture(Resource1.btnChoose); // Image 575 x 101
            btnChoose.Position = new Vector2f(_position.X + 5, _position.Y + 5);
            btnChoose.Size = new Vector2f(580, 50);
            btnChoose.ClickedEvent += btnChooseClick;

            //lblName = wh.CreateLabel();
            //lblName.Text = new Text(_user.Name,new Font(Resource1.CENTURY));

            RectangleShape image = new RectangleShape(new Vector2f(580,400));

            image.Position = new Vector2f(_position.X + 5, _position.Y + 5 + btnChoose.Size.Y + 5);
            image.FillColor = Color.Black;
            image.OutlineColor = Color.Black;
            image.Texture = _image;

            _w.Draw(rect);
            _w.Draw(image);
        }
    }
}
