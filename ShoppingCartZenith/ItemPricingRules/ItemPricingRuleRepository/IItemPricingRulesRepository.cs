namespace ShoppingCartZenith.ItemPricingRules.ItemPricingRuleRepository
{
    public interface IItemPricingRulesRepository
    {


        void AddItemPricingRule(char sku, int quantity, int price);
    }
}
