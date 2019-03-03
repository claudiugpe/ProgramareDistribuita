namespace Server.Models
{
    public class Item
    {
        public Item(string plu, string description, decimal Price)
        {
            this.Plu = plu;
            this.Description = description;
            this.Price = Price;
        }

        public string Plu { get; private set; }

        public decimal Price { get; private set; }

        public string Description { get; private set; }

        public override string ToString()
        {
            return $"PLU: {this.Plu} - {this.Description} for {this.Price}";
        }
    }
}
