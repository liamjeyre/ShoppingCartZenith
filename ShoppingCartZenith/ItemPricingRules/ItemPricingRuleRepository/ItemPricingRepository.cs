namespace ShoppingCartZenith.ItemPricingRules.ItemPricingRuleRepository
{
    public class ItemPricingRepository : IItemPricingRulesRepository
    {
        private List<ItemPricingRule> Rules { get; }

        public ItemPricingRepository() 
        { 
            Rules = [];
        }

        public void AddItemPricingRule(char sku, int quantity, int price)
        {
            var rule = new ItemPricingRule(sku, quantity, price);

            Rules.Add(rule);
        }

        public List<ItemPricingRule> GetItemPricingRules()
        {
            return Rules;
        }
    }
}
