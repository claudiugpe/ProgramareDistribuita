using Server.Database;
using System.Collections.Generic;
using System.Linq;

namespace Server.Models
{
    public class Cart
    {
        public Cart()
        {
            this.ItemRepository = new ItemRepository();
        }

        public List<Item> Items { get; private set; }

        public decimal Total { get; private set; }

        public ItemRepository ItemRepository { get; }

        public void StartCart()
        {
            this.Items = new List<Item>();
            this.Total = decimal.Zero;
        }

        public bool AddItem(string plu)
        {
            var pluToFind = plu.Split("\0")[0];
            var items = this.ItemRepository.GetItems();

            var item = items.FirstOrDefault(x => string.CompareOrdinal(x.Plu, pluToFind) == 0);

            if(item == null)
            {
                return false;
            }

            this.Items.Add(item);
            this.UpdateTotal();
            return true;
        }

        public void RemoveItem(int position)
        {
            this.Items.RemoveAt(position);
            this.UpdateTotal();
        }

        public decimal GetTotal()
        {
            return this.Total;
        }

        public string PrintCart()
        {
            var result = string.Empty;
            this.Items.ForEach(x => result = result + x.ToString());

            return result;
        }

        public override string ToString()
        {
            var result = string.Empty;
            this.Items.ForEach(x => result = result + x.ToString() + "&nbsp;");
            result = result + "Total: " + this.Total;

            return result;
        }

        private void UpdateTotal()
        {
            this.Total = this.Items.Sum(x => x.Price);
        }
    }
}
