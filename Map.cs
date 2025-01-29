using System;
using System.Collections.Generic;

namespace DGD203_CengizBuğraGökakın_TextAdventuregame
{
    public class Map
    {
        private Dictionary<string, Location> locations;

        public Map()
        {
            locations = new Dictionary<string, Location>();
            InitializeLocations();
        }

        private void InitializeLocations()
        {
            // Example NPCs
            NPC villager = new NPC("Villager", new List<string> { "Hello!", "Isn't it a beautiful day?", "Can I help you?" });
            NPC sage = new NPC("Sage", new List<string> { "Knowledge is power.", "Choose the right path.", "Be strong." });

            // Add locations with descriptions and interactive items
            locations["forest"] = new Location("Forest", "You are in a dense forest. You can hear the birds singing.", villager, new List<string> { "key", "pebbles" });
            locations["cave"] = new Location("Cave", "You entered a dark cave. You can hear water dripping.", items: new List<string> { "torch", "old map" });
            locations["village"] = new Location("Village", "You are in a small village. People are going about their daily business.", villager);
            locations["lake"] = new Location("Lake", "You are by a calm lake. The water is clear and cool.", items: new List<string> { "golden fish", "water bottle" });
            locations["mountain"] = new Location("Mountain", "You are at the top of a high mountain. The view is magnificent.", sage, items: new List<string> { "precious stone", "crystal shard" });
            locations["secret rooms"] = new Location("Secret Rooms", "You entered a secret room. There is a door here, but it's locked.", usableItems: new List<string> { "key", "torch" });
            locations["temple"] = new Location("Temple", "You entered an ancient temple. There is a ritual area.", usableItems: new List<string> { "precious stone", "old map" });
            locations["desert"] = new Location("Desert", "You are walking in a vast desert. The sands shine like gold.", items: new List<string> { "hourglass", "mysterious stone" });
            locations["swamp"] = new Location("Swamp", "You are in a dangerous swamp. Every step must be careful.", items: new List<string> { "swamp plant", "poisoned arrow" });
            locations["castle"] = new Location("Castle", "You entered an old castle. The walls tell a story.", items: new List<string> { "sword", "shield" });
            locations["port"] = new Location("Port", "You are at a port. Ships are coming and going.", items: new List<string> { "sea map", "diving suit" });
            locations["farm"] = new Location("Farm", "You are on a farm. It is full of animals and plants.", items: new List<string> { "milk", "egg" });
        }

        public void DisplayLocation(string locationName)
        {
            if (locations.ContainsKey(locationName.ToLower()))
            {
                Console.WriteLine(locations[locationName.ToLower()].Description);
                locations[locationName.ToLower()].Interact();
            }
            else
            {
                Console.WriteLine("This location does not exist.");
            }
        }

        public void DisplayAvailableLocations()
        {
            Console.WriteLine("Available locations:");
            foreach (var location in locations)
            {
                Console.WriteLine($"- {location.Key}");
            }
        }

        public bool IsValidLocation(string locationName)
        {
            return locations.ContainsKey(locationName.ToLower());
        }

        public void DisplayItemsAtLocation(string locationName)
        {
            if (locations.ContainsKey(locationName.ToLower()))
            {
                var location = locations[locationName.ToLower()];
                if (location.Items.Count > 0)
                {
                    Console.WriteLine("Items you can find here:");
                    foreach (var item in location.Items)
                    {
                        Console.WriteLine($"- {item}");
                    }
                }
                else
                {
                    Console.WriteLine("There are no items to collect here.");
                }
            }
        }

        public void DisplayUsableItemsAtLocation(string locationName, Inventory inventory)
        {
            if (locations.ContainsKey(locationName.ToLower()))
            {
                var location = locations[locationName.ToLower()];
                Console.WriteLine("Items you can use in this location:");
                foreach (var item in inventory.Items)
                {
                    if (location.UsableItems.Contains(item))
                    {
                        Console.WriteLine($"- {item}");
                    }
                }
            }
        }

        public bool CollectItemAtLocation(string item, string locationName)
        {
            if (locations.ContainsKey(locationName.ToLower()))
            {
                var location = locations[locationName.ToLower()];
                if (location.Items.Contains(item))
                {
                    location.Items.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public void UseItemAtLocation(string item, string locationName)
        {
            if (locations.ContainsKey(locationName.ToLower()))
            {
                var location = locations[locationName.ToLower()];
                if (location.UsableItems.Contains(item))
                {
                    Console.WriteLine($"{item} used in this location.");
                    location.UsableItems.Remove(item);
                    location.Description += $" {item} used.";
                    if (locationName.ToLower() == "secret rooms" && item.ToLower() == "key")
                    {
                        Console.WriteLine("You used the key to unlock the door in the secret room! You found an old map inside.");
                        location.Items.Add("old map");
                    }
                    else if (locationName.ToLower() == "temple" && item.ToLower() == "precious stone")
                    {
                        Console.WriteLine("You placed the precious stone in the ritual area. A hidden passage has opened!");
                        location.Description += " A hidden passage has opened.";
                    }
                    else if (locationName.ToLower() == "temple" && item.ToLower() == "old map")
                    {
                        Console.WriteLine("You used the old map to find the hidden room in the temple!");
                        location.Description += " You found a treasure in the hidden room!";
                    }
                }
                else
                {
                    Console.WriteLine($"{item} cannot be used here.");
                }
            }
            else
            {
                Console.WriteLine("This location does not exist.");
            }
        }

        public void InteractWithNPC(string locationName)
        {
            if (locations.ContainsKey(locationName.ToLower()))
            {
                var location = locations[locationName.ToLower()];
                if (location.HasNPC)
                {
                    Console.WriteLine($"You encountered an NPC at {location.Name}. Interacting with the NPC.");
                    location.InteractWithNPC();
                }
                else
                {
                    Console.WriteLine("There is no NPC to interact with in this location.");
                }
            }
            else
            {
                Console.WriteLine("This location does not exist.");
            }
        }
    }
}