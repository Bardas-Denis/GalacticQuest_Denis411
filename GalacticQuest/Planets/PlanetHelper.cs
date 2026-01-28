
using GalacticQuest.Items;
using GalacticQuest.Monsters;
using System.Runtime.CompilerServices;

namespace GalacticQuest.Planets
{
    internal static class PlanetHelper
    {
        internal static readonly IList<IPlanet> PLANETS_LIST = new List<IPlanet>() { new PlanetMeridian(), new PlanetNibiru(), new PlanetVespera() };

        internal static readonly Random RandomNumberGenerator = new Random();

        private const int ITEM_DROP_PROBABILITY_FROM_PLANET = 35;

        private static int _currentPlanetIndex = -1;

        /// <summary>
        /// Randomly travels to one of the planets found in the PLANETS_LIST
        /// </summary>
        internal static void TravelToRandomPlanet()
        {
            // random number generator takes an exclusive upper bound as second argument -> so for (0,3) it will pick from integers 0 1 2
            int randomPlanetIndex = RandomNumberGenerator.Next(0, PLANETS_LIST.Count);
            IPlanet chosenPlanet = PLANETS_LIST.ElementAt(randomPlanetIndex);

            _currentPlanetIndex = randomPlanetIndex;
            Console.WriteLine($" You travelled to planet : {chosenPlanet.GetType().ToString().Split(".").Last()} ");

            Monster? randomMonster = ChooseRandomMonsterFromPlanet(chosenPlanet);

            if (randomMonster is null)
            {
                Console.WriteLine("Unfortunately no monsters live on this planet :( ");
                return;
            }

            Console.WriteLine($" You have encountered a monster of type : {randomMonster.GetType().ToString().Split(".").Last()}, called by their name {randomMonster?.Name} with {randomMonster?.Hp} HP ");
            DoBattleWithMonster(randomMonster);
        }

        /// <summary>
        /// Handles battle between the player and a monster
        /// </summary>
        internal static void DoBattleWithMonster(Monster? monster)
        {
            if (monster is null)
            {
                return;
            }

            Console.Write("\n");
            while (Program.currentPlayer.Hp > 0 && monster.Hp > 0)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Player: {Program.currentPlayer.Hp} HP | {monster.Name}: {monster.Hp} HP");
                Console.WriteLine("Choose your action: [1] Attack  [2] Run");
                string choice = Console.ReadLine() ?? "";

                if (choice == "1")
                {
                    Console.WriteLine($"You attack the {monster.Name}!");
                    monster.Hp -= Program.currentPlayer.Attack;
                    Console.WriteLine($"You dealt {Program.currentPlayer.Attack} damage.");
                }
                else if (choice == "2")
                {
                    int runAttempt = Random.Shared.Next(1, 11);
                    int failThreshold = 4;

                    if (runAttempt >= failThreshold)
                    {
                        Console.WriteLine("You successfully ran away!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You failed to escape! The monster blocks your path.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice! You stumble, giving the monster an opening.");
                }

                if (monster.Hp <= 0) break;

                Console.WriteLine($"{monster.Name} attacks you!");
                Program.currentPlayer.UpdateHp(-monster.Attack);
                Console.WriteLine($"The {monster.Name} dealt {monster.Attack} damage.");
            }
            if (Program.currentPlayer.Hp <= 0)
            {
                Console.WriteLine("\nNooo you lost... Game Over.");
            }
            else if (monster.Hp <= 0)
            {
                Console.WriteLine($"\nPlayer WON the battle against {monster.Name} !!!!");
                monster.OnDeath();
            }
        }

        /// <summary>
        /// Searches for a random item/s and displays what item/s the player received
        /// </summary>
        internal static void SearchForItems()
        {
            int randomProbability = RandomNumberGenerator.Next(0, 100);

            if (randomProbability < ITEM_DROP_PROBABILITY_FROM_PLANET)
            {
                Console.WriteLine("Sorry! No item found on this planet right now !");
                return;
            }

            Item? foundItem = ChooseRandomItemFromPlanet(PLANETS_LIST.ElementAtOrDefault(_currentPlanetIndex));
            if (foundItem is null)
            {
                Console.WriteLine("Sorry! No item found on this planet right now !");
                return;
            }

            Program.currentPlayer.AddItemToBackpack(foundItem);
            Console.WriteLine($"Congrats! You picked up a new item : {foundItem.Name} with Attack - {foundItem.Attack} and Resistance - {foundItem.Resitance}");
        }


        /// <summary>
        /// Picks a random monster found on that specific planet
        /// </summary>
        /// <param name="planet"> The planet on which to find monsters </param>
        /// <returns> The found monster, otherwise null </returns>
        private static Monster? ChooseRandomMonsterFromPlanet(IPlanet planet)
        {
            IList<Monster> monstersOnPlanet = planet?.GetInhabitants();

            if (monstersOnPlanet is null || monstersOnPlanet.Count < 1)
            {
                return null;
            }

            return monstersOnPlanet.ElementAtOrDefault(RandomNumberGenerator.Next(0, monstersOnPlanet.Count));
        }

        /// <summary>
        /// Picks a random item (with a random chance of dropping) from the specified planet
        /// </summary>
        /// <param name="planet"> The planet from which to choose a random item </param>
        /// <returns> The found item, otherwise null </returns>
        private static Item? ChooseRandomItemFromPlanet(IPlanet planet)
        {
            IList<Item> itemsOnPlanet = planet?.GetAvailableItems();

            if (itemsOnPlanet is null || itemsOnPlanet.Count < 1)
            {
                return null;
            }

            return itemsOnPlanet.ElementAtOrDefault(RandomNumberGenerator.Next(0, itemsOnPlanet.Count));
        }
    }
}