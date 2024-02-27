using System;

namespace game
{
    class Program
    {
        public int playerY = 5;
        public int playerX = 3;
        static void Main(string[] args)
        {
            World.QuestByID(1).DisplayQuestInfo();
            Console.WriteLine("Your current location is: " + locatie);
            Console.WriteLine("  P  ");
            Console.WriteLine("  A  ");
            Console.WriteLine("VFTGBS");
            Console.WriteLine("  H  ");

            Console.WriteLine("Which direction do you want to go? (north/south/east/west)");
            string direction = Console.ReadLine();

            // TODO: Handle the user's chosen direction and update the game accordingly

            Console.WriteLine("You chose to go " + direction + "."); // Placeholder output

        }
    }
}
