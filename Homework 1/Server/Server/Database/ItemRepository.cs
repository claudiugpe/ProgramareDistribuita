using Server.Models;
using System.Collections.Generic;

namespace Server.Database
{
    public class ItemRepository
    {
        public ItemRepository()
        {
            this.Items = new List<Item>
            {
                new Item("01010101", "Oranges", 2.5M),
                new Item("02020202", "Chocolate", 3M),
                new Item("03030303", "Water", 1.5M)
            };
        }

        private List<Item> Items { get; set; }

        public List<Item> GetItems()
        {
            return this.Items;
        }
    }
}
