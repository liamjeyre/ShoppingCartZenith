namespace ShoppingCartZenith.ItemPricingRules
{
    public class ItemPricingRule(char sku, int quantity, int price) : IItemPricingRule
    {
        public char SKU { get; set; } = sku;
        public int Quantity { get; set; } = quantity;
        public int Price { get; set; } = price;
    }
}
