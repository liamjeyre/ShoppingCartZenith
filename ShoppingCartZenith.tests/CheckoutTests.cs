using Moq;
using ShoppingCartZenith.Checkout;
using ShoppingCartZenith.ItemPricingRules.ItemPricingRuleRepository;

namespace ShoppingCartZenith.tests
{
    internal class CheckoutTests
    {
        private Mock<IItemPricingRulesRepository> ItemRulesRepo;
        private CheckoutScanner Checkout;

        [SetUp]
        public void SetUp()
        {
            ItemRulesRepo = new Mock<IItemPricingRulesRepository>();
            Checkout = new CheckoutScanner(ItemRulesRepo.Object);
        }

        [Test]
        public void TestScanItem()
        {
            Checkout.Scan('A');

            Assert.That(Checkout.Items[0], Is.EqualTo('A'));
        }

        [Test]
        public void TestScanMultipleItems()
        {
            Checkout.Scan('A');
            Checkout.Scan('B');
            Checkout.Scan('C');
            Checkout.Scan('D');

            Assert.Multiple(() => {
                Assert.That(Checkout.Items[0], Is.EqualTo('A'));
                Assert.That(Checkout.Items[1], Is.EqualTo('B'));
                Assert.That(Checkout.Items[2], Is.EqualTo('C'));
                Assert.That(Checkout.Items[3], Is.EqualTo('D'));
            });
        }
    }
}
