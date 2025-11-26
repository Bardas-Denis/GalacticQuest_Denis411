using GalacticQuest.Enums;
using System.Security.Cryptography.X509Certificates;

namespace GalacticQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isGameRunning = true;
            Dictionary<string, Tuple<int,int>> monsterHealth = new Dictionary<string, Tuple<int, int>>()
            {

                {"Monster1", Tuple.Create(100,20) },
                {"Monster2", Tuple.Create(150,25)},
                {"Monster3", Tuple.Create(300,10)} ,
                {"Monster4", Tuple.Create(200,20)},
                {"Monster5", Tuple.Create(160,40)},
                {"Monster6", Tuple.Create(50,100)},
                {"Monster7", Tuple.Create(350,45)}
            };

            while (isGameRunning)
            {
                MainMenu();
                string input = Console.ReadLine();
                int.TryParse(input, out int inputValue);
                switch (inputValue)
                {
                    case (int)MainMenuOptions.Travel:
                        Console.WriteLine("You choosed travel");
                        bool isTraveling = true;
                        while (isTraveling)
                        { 
                            TravelMenu();
                            input = Console.ReadLine();
                            int.TryParse(input, out inputValue);
                            switch (inputValue)
                            {
                                case (int)Travel.Explore:
                                    Console.WriteLine("You choosed Explore");
                                    break;
                                case (int)Travel.SearchForItems:
                                    Console.WriteLine("You choosed search for items");
                                    break;
                                case (int)Travel.BackToShip:
                                    Console.WriteLine("You choosed back to ship");
                                    break;
                                case (int)Journal.Exit:
                                    isTraveling = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid option");
                                    break;
                            }
                        }
                        break;
                    case (int)MainMenuOptions.Journal:
                        Console.WriteLine("You choosed journal");
                        bool isInJournal = true;
                        while (isInJournal)
                        {
                            JournalMenu();
                            input = Console.ReadLine();
                            int.TryParse(input, out inputValue);
                            switch (inputValue)
                            {
                                case (int)Journal.Monsters:
                                    Console.WriteLine("You choosed monsters");
                                    ShowMonsters(monsterHealth);
                                    bool isInMonsterMenu = true;
                                    while (isInMonsterMenu)
                                    {
                                        MonsterMenu();
                                        input = Console.ReadLine();
                                        int.TryParse(input, out inputValue);
                                        switch (inputValue)
                                        {
                                            case 1:
                                                FilterByName(monsterHealth);
                                                break;
                                            case 2:
                                                isInMonsterMenu = false;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid option");
                                                break;
                                        }
                                    }
                                    break;
                                case (int)Journal.Planets:
                                    Console.WriteLine("You choosed planets");
                                    break;
                                case (int)Journal.Items:
                                    Console.WriteLine("You choosed items");
                                    break;
                                case (int)Journal.Exit:
                                    isInJournal = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid option");
                                    break;
                            }
                        }
                        break;
                    case (int)MainMenuOptions.Exit:
                        Console.WriteLine("You choosed exit");
                        isGameRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Travel");
            Console.WriteLine("2. Journal");
            Console.WriteLine("3. Exit");
        }
        public static void TravelMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Explore");
            Console.WriteLine("2. Search for items");
            Console.WriteLine("3. Back to ship");
            Console.WriteLine("4. Back");
        }
        public static void JournalMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Monsters");
            Console.WriteLine("2. Planets");
            Console.WriteLine("3. Items");
            Console.WriteLine("4. Back");
        }
        public static void MonsterMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Filter by Name");
            Console.WriteLine("2. Back");
        }
        public static void ShowMonsters(Dictionary<string, Tuple<int,int>> monsterHealth)
        {
            foreach (var monster in monsterHealth)
            {
                Console.WriteLine($"{monster.Key}: {monster.Value.Item1} HP, {monster.Value.Item2} AD");
            }
        }
        public static void FilterByName(Dictionary<string, Tuple<int, int>> monsterHealth)
        {
            Console.WriteLine("Enter the name to filter:");
            string nameFilter = Console.ReadLine();
            var filteredMonsters = monsterHealth.Where(m => m.Key.Contains(nameFilter, StringComparison.OrdinalIgnoreCase));
            if (filteredMonsters.Any())
            {
                foreach (var monster in filteredMonsters)
                {
                    Console.WriteLine($"{monster.Key}: {monster.Value.Item1} HP, {monster.Value.Item2} AD");
                }
            }
            else
            {
                Console.WriteLine("No monsters found with that name.");
                ShowMonsters(monsterHealth);
            }
        }

    }
}
