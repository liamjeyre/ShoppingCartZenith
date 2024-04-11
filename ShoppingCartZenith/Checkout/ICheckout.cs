namespace ShoppingCartZenith.Checkout
{
    public interface ICheckout
    {
        void Scan(string itemSKU);
        int GetTotalPrice();
    }
}
