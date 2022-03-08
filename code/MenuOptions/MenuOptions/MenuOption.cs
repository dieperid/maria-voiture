using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MenuOptions
{
    /// <summary>
    /// Class MenuOptions
    /// </summary>
    class MenuOption
    {
        #region[Attributs]
        /// <summary>
        /// Boolean pour le son du jeu
        /// </summary>
        private bool _sound;
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
        /// Shape pour le texte ON
        /// </summary>
        private RectangleShape _sliderSoundShape;
        /// <summary>
        /// Texture pour le text ON
        /// </summary>
        private Texture _sliderSoundTexture;
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
        /// <summary>
        /// Getter, setter sur _titleShape
        /// </summary>
        public RectangleShape TitleShape
        {
            get { return _titleShape; }
            set { _titleShape = value; }
        }
        /// <summary>
        /// Getter, setter sur _soundShape
        /// </summary>
        public RectangleShape SoundShape
        {
            get { return _soundShape; }
            set { _soundShape = value; }
        }
        /// <summary>
        /// Getter, setter sur _textOnShape
        /// </summary>
        public RectangleShape TextOnShape
        {
            get { return _textOnShape; }
            set { _textOnShape = value; }
        }
        /// <summary>
        /// Getter, setter sur _textOffShape
        /// </summary>
        public RectangleShape TextOffShape
        {
            get { return _textOffShape; }
            set { _textOffShape = value; }
        }
        /// <summary>
        /// Getter, setter sur _titleShape
        /// </summary>
        public RectangleShape SliderSoundShape
        {
            get { return _sliderSoundShape; }
            set { _sliderSoundShape = value; }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe MenuOption
        /// </summary>
        public MenuOption(uint windowWidth, uint windowHeight)
        {
            InitializeOptionsTitle(windowWidth);
            InitializeSoundTitle(windowWidth, windowHeight);
            InitializeOnOffText(windowWidth, windowHeight);
            SliderSound();
        }

        public void InitializeOptionsTitle(uint windowWidth)
        {
            _titleTexture = new Texture(Images.title_options) { Smooth = true };
            _titleShape = new RectangleShape(new Vector2f(_titleWidth, _titleHeight))
            {
                Texture = _titleTexture,
                FillColor = Color.Black,
                Position = new Vector2f((windowWidth - _titleWidth) / 2, 0 + _titleHeight)
            };
        }

        public void InitializeSoundTitle(uint windowWidth, uint windowHeight)
        {
            _soundTexture = new Texture(Images.title_sound) { Smooth = true };
            _soundShape = new RectangleShape(new Vector2f(_soundWidth, _soundHeight))
            {
                Texture = _soundTexture,
                FillColor = Color.Black,
                Position = new Vector2f((windowWidth - _soundWidth) / 2, (windowHeight - 3 * _soundHeight) / 2)
            };
        }

        public void InitializeOnOffText(uint windowWidth, uint windowHeight)
        {
            _textOnTexture = new Texture(Images.options_text_on) { Smooth = true };
            _textOnShape = new RectangleShape(new Vector2f(_textOnWidth, _textOnHeight))
            {
                Texture = _textOnTexture,
                FillColor = Color.Black,
                Position = new Vector2f((windowWidth - _textOnWidth - _soundWidth) / 2, (windowHeight - 1 * _textOnHeight) / 2)
            };

            _textOffTexture = new Texture(Images.options_text_off) { Smooth = true };
            _textOffShape = new RectangleShape(new Vector2f(_textOffWidth, _textOffHeight))
            {
                Texture = _textOffTexture,
                FillColor = Color.Black,
                Position = new Vector2f((windowWidth + _textOffWidth) / 2, (windowHeight - 1 * _textOffHeight) / 2)
            };
        }

        public void SliderSound()
        {
            if (_sound == true)
            {
                _sliderSoundTexture = new Texture(Images.slider_on) { Smooth = true };
            }
            else
            {
                _sliderSoundTexture = new Texture(Images.slider_off) { Smooth = true };
            }
            _sliderSoundShape = new RectangleShape(new Vector2f(_sliderSoundWidth, _sliderSoundHeight))
            {
                Texture = _sliderSoundTexture,
                Position = new Vector2f(((_textOffShape.Position.X - (_textOnShape.Position.X + _textOnWidth)) / 2) + _textOnShape.Position.X + _textOnWidth - 92, _textOnShape.Position.Y + 24)
            };
        }
    }
}
