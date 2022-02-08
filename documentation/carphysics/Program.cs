using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SFML_Engine;
using Physics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1920, 1080, "Car physics");
            game.Run();
            LogHandler.GetInstance().ShowLogs();
        }
    }

    class CarPhysX : GameState
    {
        Car _myCar;
        Label lbl;
        Button btn;

        public CarPhysX(string name, StateHandler sh, AssetManager am, InputHandler ih, GameClock gc, RenderWindow w, WidgetHandler wh) : base(name, sh, am, ih, gc, w, wh)
        {
        }

        public override void Load()
        {
            _assetManager.Loadfiles(@"C:\Users\pq34bsi\Desktop\CarPhysics\Asset");
            _widgetHandler.Font = _assetManager.GetFont("ayar.ttf");
            _myCar = new Car(80, 150, 100, 100, 0, new Vector2f(1920f/2f, 1080f/2f));
            lbl = _widgetHandler.CreateLabel();
            lbl.Position = new Vector2f(0, 0);
            btn = _widgetHandler.CreateButton();
            btn.Color = Color.Red;
            btn.Position = new Vector2f(0, 1030);
            btn.Size = new Vector2f(300, 150);
            btn.Text = "Reload";
            btn.ClickedEvent += Btn_ClickedEvent;
        }

        private void Btn_ClickedEvent(object sender, EventArgs e)
        {
            _myCar = new Car(80, 150, 100, 100, 0, new Vector2f(1920f / 2f, 1080f / 2f));
        }

        public override void Update()
        {
            float turnRate = 500;
            if (_inputHandler.IsPressed(Keyboard.Key.W))
            {
                _myCar.Accelerate(_gameClock.ElapsedFrame());
            }
            if (_inputHandler.IsPressed(Keyboard.Key.A))
            {
                _myCar.Turn(true, turnRate, _gameClock.ElapsedFrame());
            }
            if (_inputHandler.IsPressed(Keyboard.Key.D))
            {
                _myCar.Turn(false, turnRate, _gameClock.ElapsedFrame());
            }
            if (_inputHandler.IsPressed(Keyboard.Key.Space))
            {
                _myCar.Break(_gameClock.ElapsedFrame());
            }
            _myCar.Update(_gameClock.ElapsedFrame());
            lbl.Text = $"Heading : {_myCar.Heading * 180 / (float)Math.PI:0.0}\n" +
                       $"Velocity : X:{_myCar.Velocity.X:0.0} Y: {_myCar.Velocity.Y:0.0}\n" +
                       $"Speed : {(float)Math.Sqrt(_myCar.Velocity.X * _myCar.Velocity.X + _myCar.Velocity.Y * _myCar.Velocity.Y):0} Pixels/Seconds\n" +
                       $"Position : X:{_myCar.Position.X:0.0} Y: {_myCar.Position.Y:0.0}";
        }

        public override void Render()
        {
            _myCar.Render(_window);
        }

    }
}
