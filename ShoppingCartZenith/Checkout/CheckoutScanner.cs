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
            throw new NotImplementedException();
        }

    }
}
