using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models.Items
{
    public class Dawncleaver: Item
    {
        public override string Name { get; set; } = "Dawncleaver";
        public override int Attack { get; set; } = 40;
        public override int HP { get; set; } = 30;
        public override void SpecialPower()
        {
            Console.WriteLine("Dawncleaver glows with the light of a thousand suns, searing enemies with its radiant power!");
        }
    }
}
