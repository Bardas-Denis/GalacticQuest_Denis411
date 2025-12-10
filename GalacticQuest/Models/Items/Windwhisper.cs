using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models.Items
{
    public class Windwhisper: Item
    {
        public override string Name { get; set; } = "Windwhisper";
        public override int Attack { get; set; } = 25;
        public override int HP { get; set; } = 15;
        public override void SpecialPower()
        {
            Console.WriteLine("Windwhisper summons a gentle breeze that confuses enemies, lowering their accuracy!");
        }
    }
}
