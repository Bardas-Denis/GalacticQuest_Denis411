using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models.Monsters
{
    public class Skullrender: Monster
    {
        public override string Name { get; set; } = "Skullrender";
        public override int Hp { get; set; } = 150;
        public override int Attack { get; set; } = 20;
        public override void BattleCry()
        {
            Console.WriteLine($"FEEL THE WRATH OF THE UNDEAD! I AM {Name}!");
        }
        public override void OnDeath()
        {
            Console.WriteLine("THE SKULL RENDERS NO MORE...");
        }
    }
}
