using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SFML_Engine;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1920, 1080, "Car physics");
            game.Run();
            LogHandler.GetInstance().ShowLogs();
            Console.ReadLine();
        }
    }

    class CarPhysX : GameState
    {
        Label lbl;
        Button btn;
        Button toggleFrcition;
        Car _car;
        Sprite _background;
        Slider _enginePower;
        Slider _friction;
        Slider _turnRate;

        public CarPhysX(string name, StateHandler sh, AssetManager am, InputHandler ih, GameClock gc, RenderWindow w, WidgetHandler wh) : base(name, sh, am, ih, gc, w, wh)
        {
        }

        public override void Load()
        {
            _assetManager.Loadfiles(@"../../../../../Asset");
            _background = new Sprite(_assetManager.GetTexture("racetrack.jpg"));
            _car = new Car(new Vector2f(1920 / 2, 1080 / 2), 604 / 12, 763 / 12, _assetManager.GetTexture("CarTexture.png"));
            _widgetHandler.Font = _assetManager.GetFont("ARIAL.TTF");

            lbl = _widgetHandler.CreateLabel();
            lbl.Position = new Vector2f(0, 0);

            btn = _widgetHandler.CreateButton();
            btn.Color = Color.Red;
            btn.Position = new Vector2f(0, 1030);
            btn.Size = new Vector2f(300, 150);
            btn.Text = "Reload";
            btn.ClickedEvent += Btn_ClickedEvent;

            _enginePower = _widgetHandler.CreateSlider("Engine Power");
            _enginePower.Position = new Vector2f(1600, 60);
            _enginePower.Min = 0;
            _enginePower.Max = 1000;
            _enginePower.Size = new Vector2f(200, 0);

            _turnRate = _widgetHandler.CreateSlider("Turn rate");
            _turnRate.Position = new Vector2f(1600, 200);
            _turnRate.Min = 0;
            _turnRate.Max = 360;
            _turnRate.Size = new Vector2f(200, 0);
        }

        private void Btn_ClickedEvent(object sender, EventArgs e)
        {
            _car.Heading = 0;
            _car.Velocity = new Vector2f(0, 0);
            _car.Position = new Vector2f(1920 / 2, 1080 / 2);
        }


        public override void Update()
        {
            lbl.Text = $"Heading: {_car.Heading:0.00}\n" +
                       $"Speed: {_car.Speed:0.00}\n" +
                       $"Dot Vel-Heading: {_car._dot_Vel_Heading:0.00}\n" +
                       $"Dot Left-Vel: {_car._dot_Vel_Left:0.00}\n" +
                       $"Dot Right-Vel: {_car._dot_Vel_Right:0.00}\n";
            
            _car.Update(_gameClock.ElapsedFrame());
            _car.TurnSpeed = _turnRate.Value * (float)Math.PI / 180;
            _car.EnginePower = _enginePower.Value;

            if (_inputHandler.IsPressed(Keyboard.Key.W))
            {
                _car.Throttle = 1;
            }
            else
            {
                _car.Throttle = 0;
            }
            if (_inputHandler.IsPressed(Keyboard.Key.A))
            {
                _car.Steering = -1;
            }
            else if (_inputHandler.IsPressed(Keyboard.Key.D))
            {
                _car.Steering = 1;
            }
            else
            {
                _car.Steering = 0;
            }
            if (_inputHandler.IsPressed(Keyboard.Key.Space))
            {
                _car.Brake = 1;
            }
            else
            {
                _car.Brake = 0;
            }
        }

        public override void Render()
        {
            RectangleShape rect = new RectangleShape();
            rect.Size = new Vector2f(300, 220);
            rect.FillColor = Color.Black;
            rect.Position = new Vector2f(1550,20);

            _window.Draw(_background);
            _window.Draw(rect);
            rect.Position = new Vector2f(0,0);
            _window.Draw(rect);
            _car.Render(_window);
        }

    }
}
