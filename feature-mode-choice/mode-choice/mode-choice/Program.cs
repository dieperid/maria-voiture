using System;

namespace mode_choice
{
    class Program
    {
        static void Main(string[] args)
        {
            ModeChoice modeChoice = new ModeChoice(1920, 1080, "main-menu");
            modeChoice.Run();
        }
    }
}
