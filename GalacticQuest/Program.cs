using GalacticQuest.Models.Monsters;
using GalacticQuest.Service;
using GalacticQuest.Services;

namespace GalacticQuest
{
    internal class Program
    {
        private static readonly MonsterService monsterService = new MonsterService();
        private static readonly ItemService itemService = new ItemService();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Galactic Quest!");

            //CreateAndDisplayPlayerStats();

            OpenMainMenu();
        }

        

        private static void CreateAndDisplayPlayerStats()
        {
            Console.Write("\n");

            List<(string, int)> items = new List<(string, int)>() { ("Excalibur", 500), ("Tessaiga", 1000) };
            Player player = new Player(50, 1, items, 10);
            //Player player = new Player(50, 1, items);
            //Player player = new Player(40, 2);
            //Player player = new Player(30);
            //Player player = new Player();

            player.ShowProfile();

            (string, int) newItem = ("Dragon Slayer", 1500);
            player.AddItem(newItem, 6);

            player.ShowProfile();

            player.UpdateHp(-60);
            Console.WriteLine($"After updating HP: {player.Hp}");
        }

        internal static void OpenMainMenu()
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.Write("\n");
                Console.WriteLine("Select your option and press Enter: \n 1.Travel \n 2.Journal \n 3.Exit \n");
                int.TryParse(Console.ReadLine(), out int readOption);


                try
                {
                    switch (readOption)
                    {
                        case 1:
                            OpenTravelMenu();
                            break;

                        case 2:
                            OpenJournalMenu();
                            break;

                        case 3:
                            isAppRunning = false;
                            break;

                        default:
                            throw new Exception("Invalid Option");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("(-_-') " + ex.Message);
                    isAppRunning = false;
                }
            }
        }

        internal enum GameOptions
        {
            Monsters = 1,
            Journal = 2,
            Exit = 3
        }

        internal static void OpenTravelMenu()
        {
            Console.Write("\n");
            Console.WriteLine("Select your option and press Enter: \n 1.Explore \n 2.Search For Items \n 3.Back To Ship \n 4.Back To Main Menu\n");

            int.TryParse(Console.ReadLine(), out int readOption);

            switch (readOption)
            {
                case 1:
                    Console.WriteLine("Selected Explore");
                    break;

                case 2:
                    Console.WriteLine("Selected Search For Items");
                    break;

                case 3:
                    Console.WriteLine("Selected Back To Ship");
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;

            }
        }

        internal static void OpenJournalMenu()
        {
            Console.Write("\n");
            Console.WriteLine("Select your option and press Enter: \n 1.Monsters \n 2.Planets \n 3.Items \n 4.Back To Main Menu\n");

            int.TryParse(Console.ReadLine(), out int readOption);

            switch (readOption)
            {
                case 1:
                    monsterService.ShowMonstersAndOptions();
                    break;

                case 2:
                    Console.WriteLine("Selected Planets");
                    break;

                case 3:
                    Console.WriteLine("Selected Items");
                    itemService.ShowItems();
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }
    }
}