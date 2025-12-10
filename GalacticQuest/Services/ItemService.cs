using GalacticQuest.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Services
{
    internal class ItemService
    {
        public List<Item> Items { get; set; }
        public ItemService()
        {
            Items = CreateItems();
        }
        internal List<Item> CreateItems()
        {
            List<Item> items = new List<Item>()
            {
                new Dawncleaver(),
                new Windwhisper()
            };
            return items;
        }
        internal void ShowItems()
        {
            Console.WriteLine("The items are : ");
            foreach (Item item in Items)
            {
                Console.WriteLine($"{item.Name}: HP - {item.HP}; ATTACK - {item.Attack}");
            }
            Console.Write("\n");
        }
    }
}
