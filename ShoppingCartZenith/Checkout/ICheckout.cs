namespace ShoppingCartZenith.Checkout
{
    public interface ICheckout
    {
        void Scan(char itemSKU);
        int GetTotalPrice();
    }
}
