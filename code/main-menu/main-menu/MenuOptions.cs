using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace main_menu
{
    /// <summary>
    /// Class MenuOptions héritée de GameState
    /// </summary>
    class MenuOption : GameState
    {
        #region[Attributs]
        /// <summary>
        /// Boolean pour le son du jeu
        /// </summary>
        private bool _sound = true;
        /// <summary>
        /// Shape pour le titre
        /// </summary>
        private RectangleShape _titleShape;
        /// <summary>
        /// Texture pour le titre du menu option
        /// </summary>
        private Texture _titleTexture;
        /// <summary>
        /// Shape pour le titre du son
        /// </summary>
        private RectangleShape _soundShape;
        /// <summary>
        /// Texture pour le titre du menu option
        /// </summary>
        private Texture _soundTexture;
        /// <summary>
        /// Shape pour le texte ON
        /// </summary>
        private RectangleShape _textOnShape;
        /// <summary>
        /// Texture pour le text ON
        /// </summary>
        private Texture _textOnTexture;
        /// <summary>
        /// Shape pour le texte ON
        /// </summary>
        private RectangleShape _textOffShape;
        /// <summary>
        /// Texture pour le text ON
        /// </summary>
        private Texture _textOffTexture;
        /// <summary>
        /// Largeur du titre
        /// </summary>
        private float _titleWidth = 600;
        /// <summary>
        /// Hauteur du titre
        /// </summary>
        private float _titleHeight = 200;
        /// <summary>
        /// Largeur du texte sound
        /// </summary>
        private float _soundWidth = 300;
        /// <summary>
        /// Hauteur du texte sound
        /// </summary>
        private float _soundHeight = 100;
        /// <summary>
        /// Largeur du titre
        /// </summary>
        private float _textOnWidth = 150;
        /// <summary>
        /// Hauteur du titre
        /// </summary>
        private float _textOnHeight = 100;
        /// <summary>
        /// Largeur du titre
        /// </summary>
        private float _textOffWidth = 150;
        /// <summary>
        /// Hauteur du titre
        /// </summary>
        private float _textOffHeight = 100;
        /// <summary>
        /// Largeur et hauteur du slider
        /// </summary>
        private float _sliderSoundWidth = 150;
        /// <summary>
        /// Largeur et hauteur du slider
        /// </summary>
        private float _sliderSoundHeight = 56;
        /// <summary>
        /// Initialisation d'une window
        /// </summary>
        RenderWindow _w;
        /// <summary>
        /// Initialisation d'un rectangleshape qui vas contenir le background du menu
        /// </summary>
        RectangleShape _background;
        /// <summary>
        /// Initialisation d'un bouton
        /// </summary>
        Button btnSound;
        #endregion

        #region[Properties]
        /// <summary>
        /// Getter, setter sur _sound
        /// </summary>
        public bool Sound
        {
            get { return _sound; }
            set { _sound = value; }
        }
        #endregion

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
        public MenuOption(string name, StateHandler sh, AssetManager am, InputHandler ih, GameClock gc, RenderWindow w, WidgetHandler wh) : base(name, sh, am, ih, gc, w, wh)
        {
            _w = w;
        }

        public void InitializeOptionsTitle(uint windowWidth)
        {
            _titleTexture = new Texture(Resource1.title_options) { Smooth = true };
            _titleShape = new RectangleShape(new Vector2f(_titleWidth, _titleHeight))
            {
                Texture = _titleTexture,
                Position = new Vector2f((windowWidth - _titleWidth) / 2, 0 + _titleHeight)
            };
        }

        public void InitializeSoundTitle(uint windowWidth, uint windowHeight)
        {
            _soundTexture = new Texture(Resource1.title_sound) { Smooth = true };
            _soundShape = new RectangleShape(new Vector2f(_soundWidth, _soundHeight))
            {
                Texture = _soundTexture,
                Position = new Vector2f((windowWidth - _soundWidth) / 2, (windowHeight - 3 * _soundHeight) / 2)
            };
        }

        public void InitializeOnOffText(uint windowWidth, uint windowHeight)
        {
            _textOnTexture = new Texture(Resource1.options_text_on) { Smooth = true };
            _textOnShape = new RectangleShape(new Vector2f(_textOnWidth, _textOnHeight))
            {
                Texture = _textOnTexture,
                Position = new Vector2f((windowWidth - _textOnWidth - _soundWidth) / 2, (windowHeight - 1 * _textOnHeight) / 2)
            };

            _textOffTexture = new Texture(Resource1.options_text_off) { Smooth = true };
            _textOffShape = new RectangleShape(new Vector2f(_textOffWidth, _textOffHeight))
            {
                Texture = _textOffTexture,
                Position = new Vector2f((windowWidth + _textOffWidth) / 2, (windowHeight - 1 * _textOffHeight) / 2)
            };
        }

        public void SliderSound(object sender, EventArgs e)
        {
            if (Sound == true) { Sound = false; }
            else { Sound = true; }
        }

        public void SliderTexture()
        {
            if (_sound == true){ btnSound.Texture = new Texture(Resource1.slider_on); }
            else { btnSound.Texture = new Texture(Resource1.slider_off); }
        }

        /// <summary>
        /// Méthode qui vas être lancer lors du lancement
        /// </summary>
        public override void Load()
        {
            // Création du rectangle contenant le background
            _background = new RectangleShape(new Vector2f(_window.Size.X, _window.Size.Y));

            _background.Texture = new Texture(Resource1.background);
            InitializeOptionsTitle(_w.Size.X);
            InitializeSoundTitle(_w.Size.X, _w.Size.Y);
            InitializeOnOffText(_w.Size.X, _w.Size.Y);

            // Création du bouton multijoueur
            btnSound = _widgetHandler.CreateButton();
            btnSound.Size = new Vector2f(_sliderSoundWidth, _sliderSoundHeight);
            btnSound.Position = new Vector2f(((_textOffShape.Position.X - (_textOnShape.Position.X + _textOnWidth)) / 2) + _textOnShape.Position.X + _textOnWidth - 92, _textOnShape.Position.Y + 24);
            btnSound.ClickedEvent += SliderSound;

        }

        /// <summary>
        /// Méthode ou on vas intégrer les updates
        /// </summary>
        public override void Update()
        {
            SliderTexture();
        }

        /// <summary>
        /// Méthode ou on vas vouloir afficher quelque chose
        /// </summary>
        public override void Render()
        {
            // Affichage du background toujour en premier
            _w.Draw(_background);
            _w.Draw(_textOnShape);
            _w.Draw(_textOffShape);
            _w.Draw(_titleShape);
            _w.Draw(_soundShape);
        }
    }
}
