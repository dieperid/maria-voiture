using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace main_menu
{
    class MainMenu : GameState
    {
        /// <summary>
        /// Initialisation du bouton multijoueur
        /// </summary>
        Button btnMultiplayer;

        /// <summary>
        /// Initialisation du bouton solo
        /// </summary>
        Button btnSolo;

        /// <summary>
        /// Initialisation du bouton Option
        /// </summary>
        Button btnOption;

        /// <summary>
        /// Initialisation du bouton quit
        /// </summary>
        Button btnQuit;

        /// <summary>
        /// Initialisation d'un rectangleshape qui vas contenir le titre
        /// </summary>
        RectangleShape _title;

        /// <summary>
        /// Initialisation de la renderwindow
        /// </summary>
        RenderWindow _w;

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
        public MainMenu(string name, StateHandler sh, AssetManager am, InputHandler ih, GameClock gc, RenderWindow w, WidgetHandler wh) : base(name, sh, am, ih, gc, w, wh)
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
            Environment.Exit(0);
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

            // Création du rectangle contenant le titre
            _title = new RectangleShape(new Vector2f(1277, 145)); // Image 1277 x 145
            _title.Position = new Vector2f(270, 100);
            _title.Texture = new Texture(Resource1.btnTitle);

            // Création du bouton multijoueur
            btnMultiplayer = _widgetHandler.CreateButton();
            btnMultiplayer.Texture = new Texture(Resource1.btnMultiplayer); // Image 575 x 99
            btnMultiplayer.Position = new Vector2f(158, 450);
            btnMultiplayer.Size = new Vector2f(575, 99);
            btnMultiplayer.ClickedEvent += btnMultiplayerClick;
            btnMultiplayer.Over += btnOver;
            btnMultiplayer.NotOver += btnNotOver;


            //Création du bouton solo
            btnSolo = _widgetHandler.CreateButton();
            btnSolo.Texture = new Texture(Resource1.btnSolo); // Image 576 x 100
            btnSolo.Position = new Vector2f(1118, 450);
            btnSolo.Size = new Vector2f(576, 100);
            btnSolo.ClickedEvent += btnSoloClick;
            btnSolo.Over += btnOver;
            btnSolo.NotOver += btnNotOver;

            // Création du bouton options
            btnOption = _widgetHandler.CreateButton();
            btnOption.Texture = new Texture(Resource1.btnOption); // Image 575 x 101
            btnOption.Position = new Vector2f(158, 650);
            btnOption.Size = new Vector2f(575, 101);
            btnOption.ClickedEvent += btnOptionClick;
            btnOption.Over += btnOver;
            btnOption.NotOver += btnNotOver;

            // Création du bouton quit
            btnQuit = _widgetHandler.CreateButton();
            btnQuit.Texture = new Texture(Resource1.btnQuit); // Image 576 x 100
            btnQuit.Position = new Vector2f(1118, 650);
            btnQuit.Size = new Vector2f(576, 100);
            btnQuit.ClickedEvent += btnQuitClick;
            btnQuit.Over += btnOver;
            btnQuit.NotOver += btnNotOver;
        }

        /// <summary>
        /// Méthode ou on vas intégrer les updates
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Méthode ou on vas vouloir afficher quelque chose
        /// </summary>
        public override void Render()
        {
            // Affichage du background toujour en premier
            _w.Draw(_background);
            // Affichage des autres inputs
            _w.Draw(_title);
        }
    }
}
