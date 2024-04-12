namespace ShoppingCartZenith.ItemPricingRules.ItemPricingRuleRepository
{
    public interface IItemPricingRulesRepository
    {
        List<ItemPricingRule> Rules { get; }

        void AddItemPricingRule(char sku, int quantity, int price);
    }
}
