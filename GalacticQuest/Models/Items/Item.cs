using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models.Items
{
    public abstract class Item
    {
        public virtual string Name { get; set; } = "Unknown Item";
        public virtual int Attack { get; set; } = 10;
        public virtual int HP { get; set; } = 20;
        public abstract void SpecialPower();

    }
}
