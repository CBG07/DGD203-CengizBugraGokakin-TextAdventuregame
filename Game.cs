using System;

namespace DGD203_CengizBuğraGökakın_TextAdventuregame
{
    class Game
    {
        static void Main(string[] args)
        {
            Menu.ShowMenu();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void EndGame()
        {
            Console.WriteLine("Game over. Press any key to return to the menu.");
            Console.ReadKey();
            Menu.ShowMenu();
        }
    }
}