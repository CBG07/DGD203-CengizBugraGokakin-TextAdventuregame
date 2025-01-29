using System;

namespace DGD203_CengizBuğraGökakın_TextAdventuregame
{
    public static class Menu
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Text Adventure Game!");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    ShowCredits();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    ShowMenu();
                    break;
            }
        }

        public static void StartNewGame()
        {
            Player player = new Player();
            Map map = new Map();
            Console.WriteLine("Once upon a time in a faraway land, you were a brave adventurer setting out to find a lost treasure.");
            map.DisplayLocation(player.CurrentLocation);

            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\nEnter a command (go, inventory, use, collect, talk, exit): ");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "go":
                        map.DisplayAvailableLocations();
                        Console.Write("Where do you want to go? ");
                        string newLocation = Console.ReadLine();
                        if (map.IsValidLocation(newLocation))
                        {
                            player.CurrentLocation = newLocation.ToLower();
                            map.DisplayLocation(player.CurrentLocation);
                        }
                        else
                        {
                            Console.WriteLine("Invalid location.");
                        }
                        break;
                    case "inventory":
                        player.Inventory.ShowInventory();
                        break;
                    case "use":
                        map.DisplayUsableItemsAtLocation(player.CurrentLocation, player.Inventory);
                        Console.Write("Which item do you want to use? ");
                        string useItem = Console.ReadLine();
                        if (player.Inventory.HasItem(useItem))
                        {
                            Console.WriteLine($"{useItem} used.");
                            map.UseItemAtLocation(useItem, player.CurrentLocation);
                            player.Inventory.RemoveItem(useItem);
                        }
                        else
                        {
                            Console.WriteLine("This item is not in your inventory.");
                        }
                        break;
                    case "collect":
                        map.DisplayItemsAtLocation(player.CurrentLocation);
                        Console.Write("Which item do you want to collect? ");
                        string collectItem = Console.ReadLine();
                        if (map.CollectItemAtLocation(collectItem, player.CurrentLocation))
                        {
                            player.Inventory.AddItem(collectItem);
                        }
                        else
                        {
                            Console.WriteLine("This item is not here.");
                        }
                        break;
                    case "talk":
                        map.InteractWithNPC(player.CurrentLocation);
                        break;
                    case "exit":
                        playing = false;
                        Game.EndGame();
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        public static void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("Credits:");
            Console.WriteLine("Game Developer: Cengiz Buğra Gökakın.");
            Console.WriteLine($"DATE: {DateTime.UtcNow:yyyy-MM-dd}");
            // Add more credits
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            ShowMenu();
        }
    }
}