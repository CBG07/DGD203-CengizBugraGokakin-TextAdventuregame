using System;
using System.Collections.Generic;

namespace DGD203_CengizBuğraGökakın_TextAdventuregame
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasNPC => NPC != null;
        public NPC NPC { get; set; }
        public List<string> Items { get; set; }
        public List<string> UsableItems { get; set; }

        public Location(string name, string description, NPC npc = null, List<string> items = null, List<string> usableItems = null)
        {
            Name = name;
            Description = description;
            NPC = npc;
            Items = items ?? new List<string>();
            UsableItems = usableItems ?? new List<string>();
        }

        public void Interact()
        {
            if (HasNPC)
            {
                Console.WriteLine("You are talking to an NPC:");
                NPC.Speak();
            }
            else if (Items.Count > 0)
            {
                Console.WriteLine("Items you can find here:");
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else if (UsableItems.Count > 0)
            {
                Console.WriteLine("Items you can use in this location:");
                foreach (var item in UsableItems)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else
            {
                Console.WriteLine("There is nothing to interact with here.");
            }
        }

        public void InteractWithNPC()
        {
            if (HasNPC)
            {
                NPC.Speak();
            }
            else
            {
                Console.WriteLine("There is no NPC to interact with in this location.");
            }
        }
    }
}