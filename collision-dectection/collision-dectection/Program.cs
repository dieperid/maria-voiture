///ETML
///Author : Kendy Song
///Date : 08.02.2022
///Summary : Manage program running

namespace collision_detection
{
    /// <summary>
    /// Manage program running
    /// </summary>
    class Program
    {
        //Settings
        const string TITLE = "Collision-detection";
        const uint WINDOW_WIDTH = 1280;
        const uint WINDOW_HEIGHT = 720;

        static void Main()
        {
            GameManager game = new GameManager(WINDOW_WIDTH, WINDOW_HEIGHT, TITLE);
        }
    }
}