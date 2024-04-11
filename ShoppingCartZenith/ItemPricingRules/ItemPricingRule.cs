namespace ShoppingCartZenith.ItemPricingRules
{
    public class ItemPricingRule : IItemPricingRule
    {
        public char SKU { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public ItemPricingRule(char sku, int price) : this(sku, 1, price) { }

        public ItemPricingRule(char sku, int quantity, int price)
        { 
            this.SKU = sku;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
