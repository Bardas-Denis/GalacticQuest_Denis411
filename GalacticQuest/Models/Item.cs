using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public Item(string name, int attack)
        {
            Name = name;
            Attack = attack;
        }
    }
}
