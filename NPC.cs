using System;
using System.Collections.Generic;

namespace DGD203_CengizBuğraGökakın_TextAdventuregame
{
    public class NPC
    {
        public string Name { get; set; }
        public List<string> Dialogues { get; set; }
        private int currentDialogueIndex;

        public NPC(string name, List<string> dialogues)
        {
            Name = name;
            Dialogues = dialogues;
            currentDialogueIndex = 0;
        }

        public void Speak()
        {
            if (Dialogues != null && Dialogues.Count > 0)
            {
                Console.WriteLine($"{Name}: {Dialogues[currentDialogueIndex]}");
                currentDialogueIndex = (currentDialogueIndex + 1) % Dialogues.Count;
            }
            else
            {
                Console.WriteLine($"{Name}: ...");
            }
        }
    }
}