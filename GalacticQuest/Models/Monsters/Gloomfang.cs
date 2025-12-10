using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models.Monsters
{
    public class Gloomfang: Monster
    {
        public override string Name { get; set; } = "Gloomfang";
        public override int Hp { get; set; } = 120;
        public override int Attack { get; set; } = 25;
        public override void BattleCry()
        {
            Console.WriteLine($"FROM THE SHADOWS I STRIKE! I AM {Name}!");
        }
        public override void OnDeath()
        {
            Console.WriteLine("GLOOM FADES...");
        }
    }
}
