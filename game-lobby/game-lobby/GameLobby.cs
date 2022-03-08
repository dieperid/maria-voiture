using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace game_lobby
{
    class GameLobby : GameState
    {
        /// <summary>
        /// Initialisation d'un rectangleshape qui vas contenir tous les joueurs
        /// </summary>
        RectangleShape _allPlayersContainer;

        /// <summary>
        /// Initialisation d'un rectangleshape qui vas contenir la couronne du joueur hote de la partie
        /// </summary>
        RectangleShape _hostCrown;

        /// <summary>
        /// Initialisation d'un rectangleshape qui vas contenir un joueur
        /// </summary>
        RectangleShape _playerContainer;

        /// <summary>
        /// Initialisation d'un rectangleshape qui vas contenir le texte d'attente
        /// </summary>
        RectangleShape _waitTextContainer;

        /// <summary>
        /// Initialisation du bouton de début de partie
        /// </summary>
        Button _btnStart;

        /// <summary>
        /// Initialisation d'un texte en attente de l'hote
        /// </summary>
        Text _waitText;

        /// <summary>
        /// Initialisation d'un label contenant le nom du joueur
        /// </summary>
        Label _playerName;

        /// <summary>
        /// Initialisation de la renderwindow
        /// </summary>
        RenderWindow _w;

        /// <summary>
        /// Initialisation d'un rectangleshape qui vas contenir le background du menu
        /// </summary>
        RectangleShape _background;

        /// <summary>
        /// Liste de joueurs
        /// </summary>
        List<Drawable> players = new List<Drawable>();

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
        public GameLobby(string name, StateHandler sh, AssetManager am, InputHandler ih, GameClock gc, RenderWindow w, WidgetHandler wh) : base(name, sh, am, ih, gc, w, wh)
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

        /// <summary>
        /// Méthode qui va surligner tout le bouton lorsque la souris passe dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void btnOver(object sender, EventArgs args)
        {
            Button btn = sender as Button;
            btn.Color = Color.Black;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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
            //Liste fictive de joueurs
            List<string> nicknames = new List<string>();
            nicknames.Add("Thomas");
            nicknames.Add("Damien");
            nicknames.Add("Mathis");
            nicknames.Add("Samuel");
            nicknames.Add("Alexandre");
            nicknames.Add("Aurelien");

            string host = nicknames[0];         //Joueur fictif host de la partie

            // Création du rectangle contenant le background
            _background = new RectangleShape(new Vector2f(_window.Size.X, _window.Size.Y));

            _background.Texture = new Texture(Resource1.background);

            // Création du rectangle contenant le text d'attente
            _waitTextContainer = new RectangleShape(new Vector2f(800, 0));
            _waitTextContainer.Position = new Vector2f(_w.Size.X / 2 - _waitTextContainer.Size.X / 2, 100);

            // Création du text d'attente de l'hote
            _waitText = new Text("en attente de l'hote. . .", new Font("../../../Resources/pixelart.ttf"));
            _waitText.Position = new Vector2f(_waitTextContainer.Position.X, 50);
            _waitText.FillColor = Color.Black;
            _waitText.CharacterSize = 60;

            //Creation du rectangle contenant tous les joueurs
            _allPlayersContainer = new RectangleShape(new Vector2f(1400, 600));
            _allPlayersContainer.FillColor = Color.White;
            _allPlayersContainer.Position = new Vector2f(_w.Size.X / 2 - _allPlayersContainer.Size.X / 2, 200);

            //Création des rectangles contenants les joueurs
            int counter = 0;
            for (int x = 0; x < 2; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    //Placement des container des joueurs
                    _playerContainer = new RectangleShape(new Vector2f(_allPlayersContainer.Size.X / 2, _allPlayersContainer.Size.Y / 3));
                    _playerContainer.Texture = new Texture(Resource1.playerContainer);
                    _playerContainer.Position = new Vector2f(_allPlayersContainer.Position.X + _playerContainer.Size.X * x, _allPlayersContainer.Position.Y + _playerContainer.Size.Y * y);
                    players.Add(_playerContainer);

                    //Placement des noms des joueurs
                    _playerName = new Label(new Font("../../../Resources/pixelart.ttf"), _inputHandler);
                    _playerName.Text = nicknames[counter];
                    Widgets.Add(_playerName);
                    _playerName.Position = new Vector2f(_playerContainer.Position.X + _playerContainer.Size.X / 5, _playerContainer.Position.Y + _playerContainer.Size.Y / 2 - 15);

                    //Positionnement de la couronne du host de la partie
                    if(host == _playerName.Text)
                    {
                        _hostCrown = new RectangleShape();
                        _hostCrown.Size = new Vector2f(160, 150);
                        _hostCrown.Texture = new Texture(Resource1.hostCrown);
                        _hostCrown.Position = new Vector2f(_playerContainer.Position.X + _playerContainer.Size.X / 2 , _playerContainer.Position.Y + 25);
                    }

                    counter++;
                }
            }

            // Création du bouton commencer
            _btnStart = _widgetHandler.CreateButton();
            _btnStart.Texture = new Texture(Resource1.btnStart); // Image 575 x 150
            _btnStart.Size = new Vector2f(575, 150);
            _btnStart.Position = new Vector2f(_w.Size.X / 2 - _btnStart.Size.X / 2, 900);
            _btnStart.ClickedEvent += btnMultiplayerClick;
            _btnStart.Over += btnOver;
            _btnStart.NotOver += btnNotOver;
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

            //Affichage des autres inputs
            _w.Draw(_waitText);
            _w.Draw(_allPlayersContainer);

            foreach(Drawable player in players)
            {
                _w.Draw(player);
            }

            _w.Draw(_hostCrown);
        }
    }
}
