using System;
using System.Collections.Generic;

namespace DGD203_CengizBuğraGökakın_TextAdventuregame
{
    public class Inventory
    {
        public List<string> Items { get; private set; }

        public Inventory()
        {
            Items = new List<string>();
        }

        public Inventory(List<string> items)
        {
            Items = items;
        }

        public void AddItem(string item)
        {
            Items.Add(item);
            Console.WriteLine($"{item} added to inventory.");
        }

        public void RemoveItem(string item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                Console.WriteLine($"{item} removed from inventory.");
            }
            else
            {
                Console.WriteLine($"{item} is not in the inventory.");
            }
        }

        public bool HasItem(string item)
        {
            return Items.Contains(item);
        }

        public void ShowInventory()
        {
            Console.WriteLine("Inventory:");
            if (Items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
        }
    }
}