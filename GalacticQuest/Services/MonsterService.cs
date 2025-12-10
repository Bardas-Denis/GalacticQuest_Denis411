using GalacticQuest.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Service
{
    internal class MonsterService
    {
        public List<Monster> Monsters { get; set; }
        public MonsterService() 
        {
            Monsters = CreateMonsters();
        }
        internal List<Monster> CreateMonsters()
        {
            List<Monster> monsters = new List<Monster>()
            {
                new Glorbazorg(),
                new Xenotutzi(),
                new Gloomfang(),
                new Skullrender()
            };
            return monsters;
        }
        internal void ShowMonsters()
        {
            Console.WriteLine("The monsters are : ");

            foreach (Monster monster in Monsters)
            {
                monster.BattleCry();
                Console.WriteLine($"{monster.Name}: HP - {monster.Hp}; ATTACK - {monster.Attack}");
            }
            Console.Write("\n");
        }

        internal void ShowMonstersAndOptions()
        {
            ShowMonsters();
            ShowMonstersOptions();
        }

        internal void ShowMonstersOptions()
        {
            Console.WriteLine("Press 1 to go back or 2 to filter monsters based on name");

            int.TryParse(Console.ReadLine(), out int userOption);
            switch (userOption)
            {
                case 1:
                    break;

                case 2:
                    FilterMonstersByName();
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }

        internal void FilterMonstersByName()
        {
            Console.WriteLine("Enter letters to filter monsters: ");
            string? userInput = Console.ReadLine();

            Console.Write("\n");

            List<Monster> filteredMonstersByName = new List<Monster>();
            if (!string.IsNullOrEmpty(userInput))
            {
                string lowerCasedUserInput = userInput.ToLower();
                foreach (Monster monster in Monsters)
                {
                    string currentMonsterName = monster.Name;
                    string lowerCasedCurrentMonster = currentMonsterName.ToLower();

                    if (lowerCasedCurrentMonster.Contains(lowerCasedUserInput))
                    {
                        filteredMonstersByName.Add(monster);
                    }
                }
            }
            else
            {
                Console.WriteLine("No input provided. Showing all monsters.");
                Console.Write("\n");
                ShowMonsters();
            }

            if (filteredMonstersByName.Count == 0)
            {
                Console.WriteLine("None of the monsters starts with these letters.");
                Console.Write("\n");
            }
            else
            {
                foreach (Monster monster in filteredMonstersByName)
                {
                    Console.WriteLine($"{monster.Name}: HP - {monster.Hp}; ATTACK - {monster.Attack}");
                }
            }
        }
    }
}
