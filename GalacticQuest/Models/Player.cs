namespace GalacticQuest
{
    public class Player
    {
        public int Hp { get; private set; } = 100;
        public int Attack { get; private set; } = 10;
        public List<(string, int)> Items { get; private set; } = new List<(string, int)>();
        public int Credits { get; private set; } = 0;

        public Player(int hp, int attack, List<(string, int)> items, int credits)
        {
            Hp = hp;
            Attack = attack;
            Items = items;
            Credits = credits;
        }

        public Player(int hp, int attack, List<(string, int)> items)
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
            }
        }

        private void OnDeath()
        {
            Console.WriteLine("Player has died. Game Over. (-_-')");
        }

        public void AddItem((string, int) item, int price)
        {
            if (Credits < price)
            {
                {
                    Console.WriteLine("Not enough credits to purchase this item.");
                    return;
                }

            }

            UpdateCredits(-price);

            Items.Add(item);
        }

        private void UpdateCredits(int credits)
        {
            Credits += credits;
        }

        public void ShowProfile()
        {
            Console.WriteLine("/-------------------------/");
            Console.WriteLine("Displaying Player Profile:");

            Console.WriteLine($"Player HP: {Hp}");
            Console.Write("\n");

            Console.WriteLine($"Player Credits: {Credits}");
            Console.Write("\n");

            Console.WriteLine("Player Items: ");
            for (int index = 0; index < Items.Count; ++index)
            {
                Console.WriteLine($"Item -> Name: {Items[index].Item1}" + " | " + $"Attack: {Items[index].Item2}");
            }
            Console.Write("\n");

            Console.WriteLine($"Player Attack: {Attack}");
            int playerTotalAttack = Attack;
            for (int index = 0; index < Items.Count; ++index)
            {
                string itemName = Items[index].Item1;
                int itemAttack = Items[index].Item2;

                playerTotalAttack += itemAttack;
            }
            Console.WriteLine($"Player Attack (Combined With Items Attack): {playerTotalAttack}");
            Console.WriteLine("/-------------------------/");
            Console.Write("\n");
        }
    }
}