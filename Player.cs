namespace DGD203_CengizBuğraGökakın_TextAdventuregame
{
    public class Player
    {
        public string CurrentLocation { get; set; }
        public Inventory Inventory { get; set; }

        public Player()
        {
            CurrentLocation = "forest"; // Starting location
            Inventory = new Inventory();
        }
    }
}