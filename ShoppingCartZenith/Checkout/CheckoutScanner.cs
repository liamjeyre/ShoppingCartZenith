using ShoppingCartZenith.ItemPricingRules.ItemPricingRuleRepository;

namespace ShoppingCartZenith.Checkout
{
    public class CheckoutScanner : ICheckout
    {
        private IItemPricingRulesRepository _itemPricingRulesRepository;

        public List<char> Items { get; set; }

        public CheckoutScanner(IItemPricingRulesRepository itemPricingRulesRepository)
        {
            this._itemPricingRulesRepository = itemPricingRulesRepository;
            this.Items = new List<char>();
        }

        public void Scan(char itemSKU)
        {
            this.Items.Add(itemSKU);
        }

        public int GetTotalPrice()
        {
            // Initialise the total
            var total = 0;
            // Group the items by SKU to get the number of items added
            var itemsGroups = Items.GroupBy(sku => sku);

            // Go through the items by sku and work out the total using the pricing rules in the repo
            foreach (var group in itemsGroups)
            {
                // get the Pricing rules for this sku and order by quantity
                var rules = _itemPricingRulesRepository.GetItemPricingRules()
                    .Where(r => r.SKU == group.Key)
                    .OrderByDescending(r => r.Quantity);
                
                var itemCount = group.Count();

                while (itemCount > 0)
                {
                    // Get the first rule where the quantity of the item is less than 
                    // the quantity of the items in the list to add to total
                    var ruleToApply = rules.First(r => r.Quantity <= itemCount);
                    total += ruleToApply.Price;
                    itemCount -= ruleToApply.Quantity;
                }
            }
            return total;
        }
    }
}
