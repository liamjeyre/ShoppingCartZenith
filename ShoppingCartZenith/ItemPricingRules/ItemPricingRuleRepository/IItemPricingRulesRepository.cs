namespace ShoppingCartZenith.ItemPricingRules.ItemPricingRuleRepository
{
    public interface IItemPricingRulesRepository
    {
        void AddItemPricingRule(char sku, int quantity, int price);

        // Method to get item pricing rules, from the db if needed in the future
        List<ItemPricingRule> GetItemPricingRules();
    }
}
