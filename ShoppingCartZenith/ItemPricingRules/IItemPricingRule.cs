namespace ShoppingCartZenith.ItemPricingRules
{
    public interface IItemPricingRule
    {
        char SKU { get; set; }
        int Quantity { get; set; }
        int Price { get; set; }
    }
}
