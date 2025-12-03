using GalacticQuest.Models;

namespace GalacticQuest
{
    public class Player
    {
        public int Hp { get; private set; } = 100;
        public int Attack { get; private set; } = 10;
        public int Credits { get; private set; } = 50;
        public List<Item> Items { get; private set; } = new();

        public Player(int hp, int attack, List<Item> items)
        {
            Hp = hp;
            Attack = attack;
            Items = items;
        }

        public Player(int hp, int attack)
        {
            Hp = hp;
            Attack = attack;
        }

        public Player(int hp)
        {
            Hp = hp;
        }

        public Player()
        {
        }

        public void UpdateHp(int hp)
        {
            Hp += hp;

            if (Hp <= 0)
            {
                Hp = 0;
                OnDeath();
                return;
            }
        }

        public void UpdateCredits(int credits)
        {
            Credits += credits;
        }
        public void ShowProfile()
        {
            Console.WriteLine("Displaying Player Profile:");

            Console.WriteLine($"Player HP: {Hp}");
            Console.Write("\n");

            Console.WriteLine("Player Items: ");
            for (int index = 0; index < Items.Count; ++index)
            {
                Console.WriteLine($"Item -> Name: {Items[index].Name}" + " | " + $"Attack: {Items[index].Attack}");
            }
            Console.Write("\n");

            Console.WriteLine($"Player Attack: {Attack}");
            int playerTotalAttack = Attack;
            for (int index = 0; index < Items.Count; ++index)
            {
                string itemName = Items[index].Name;
                int itemAttack = Items[index].Attack;

                playerTotalAttack += itemAttack;
            }
            Console.WriteLine($"Player Attack (Combined With Items Attack): {playerTotalAttack}");
            Console.Write("\n");
        }
        public void OnDeath()
        {
            Console.WriteLine("You have died. Game over!!");
        }
        public void BuyItem(Item item)
        {
            Items.Add(item);
        }
        public void SellItem(Item item)
        {
            Items.Remove(item);
        }
    }
}