namespace GalacticQuest.Monsters
{
    public class Ignifax : Monster
    {
        public override string Name { get; set; } = "Ignifax ";
        public override int Hp { get; set; } = 140;
        public override int Attack { get; set; } = 15;

        public override void BattleCry()
        {
            Console.WriteLine($"BURN TO CINDERS! {Name} HAS ARRIVED TO CONSUME THE LIGHT");
        }

        public override void OnDeath()
        {
            Console.WriteLine("YOU DOUSE ONE SPARK... BUT THE FIRE OF DESTRUCTION IS ETERNAL! I AM ONLY THE BEGINNING OF YOUR ASH!");
        }
    }
}