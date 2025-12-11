namespace GalacticQuest.Monsters
{
    public class Kryostasis : Monster
    {
        public override string Name { get; set; } = "Kryostasis";
        public override int Hp { get; set; } = 140;
        public override int Attack { get; set; } = 15;

        public override void BattleCry()
        {
            Console.WriteLine($"FEEL THE BREATH OF WINTER'S END! I AM {Name}, AND ALL LIFE FREEZES");
        }

        public override void OnDeath()
        {
            Console.WriteLine("THIS WARMTH... IT IS FLEETING... THE COLD REMAINS... AND IT WAITS FOR YOU!");
        }
    }
}