namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your player's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your player's description: ");
            string description = Console.ReadLine();

            Player player = new Player(name, description);

            Item sword = new Item(new string[] { "sword", "blade" }, "Sword", "A sharp sword.");
            Item shield = new Item(new string[] { "shield", "buckler" }, "Shield", "A huge shield.");

            player.Inventory.Put(sword);
            sword.PrivilegeEscalation("0034");
            player.Inventory.Put(shield);

            Bag bag = new Bag(new string[] { "bag", "backpack" }, "Bag", "A bag to carry items.");
            player.Inventory.Put(bag);

            Item gun = new Item(new string[] { "gun", "pistol" }, "Gun", "A powerful gun.");
            bag.Inventory.Put(gun);

            description = player.FullDescription;
            Console.WriteLine(description);

            Location beach = new Location(new string[] { "beach" }, "The beach", "A wonderful beach");
            Location hotel = new Location(new string[] { "hotel" }, "The hotel", "A luxurious 5 star hotel");
            Location kitchen = new Location(new string[] { "kitchen" }, "The kitchen", "Smells like burnt toast.");

            Path north = new Path(new string[] { "north", "n" }, "North way", "The path that is leading to The North");
            Path east = new Path(new string[] { "east", "e" }, "East way", "The path that is leading to The East");

            north.Destination = hotel;
            east.Destination = kitchen;

            beach.AddPath(north);
            beach.AddPath(east);

            player.Location = beach;



            while (true)
            {
                Console.Write("Enter a command (0 to exit): ");
                string userinput = Console.ReadLine();

                if (userinput == "0")
                {
                    break;
                }

                CommandProcessor commandprocessor = new CommandProcessor();
                Console.WriteLine(commandprocessor.Execute(player, userinput.Split()));

            }
        }
    }
}
