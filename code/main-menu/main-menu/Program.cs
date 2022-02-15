using System;

namespace main_menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1920, 1080, "main-menu");
            game.Run();
        }
    }
}
