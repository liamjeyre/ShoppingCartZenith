using Moq;
using ShoppingCartZenith.Checkout;
using ShoppingCartZenith.ItemPricingRules;
using ShoppingCartZenith.ItemPricingRules.ItemPricingRuleRepository;

namespace ShoppingCartZenith.tests
{
    internal class CheckoutTests
    {
        private Mock<IItemPricingRulesRepository> ItemRulesRepo;
        private CheckoutScanner Checkout;

        public List<ItemPricingRule> PricingRules =
        [
            new('A', 1, 50),
            new('A', 3, 130),
            new('B', 1, 30),
            new('B', 2, 45),
            new('C', 1, 20),
            new('D', 1, 15)
        ];

        [SetUp]
        public void SetUp()
        {
            ItemRulesRepo = new Mock<IItemPricingRulesRepository>();
            ItemRulesRepo.SetupGet(itemRepo => itemRepo.Rules).Returns(PricingRules);
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

        [Test]
        public void GetTotalOfOneItemScanned()
        {
            Checkout.Scan('A');

            Assert.That(Checkout.GetTotalPrice(), Is.EqualTo(50));
        }
        [Test]
        public void GetTotalOfTwoItemsScanned()
        {
            Checkout.Scan('A');
            Checkout.Scan('D');

            Assert.That(Checkout.GetTotalPrice(), Is.EqualTo(50 + 15));
        }

        [Test]
        public void GetTotalOfSpecialPrice()
        {
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');

            Assert.That(Checkout.GetTotalPrice(), Is.EqualTo(130));
        }

        [Test]
        public void GetTotalOfSpecialPriceAndNormalPrice()
        {
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');

            Assert.That(Checkout.GetTotalPrice(), Is.EqualTo(50 + 50 + 130));
        }

        [Test]
        public void GetTotalOfUnorderedScannedItems()
        {
            Checkout.Scan('A');
            Checkout.Scan('B');
            Checkout.Scan('C');
            Checkout.Scan('A');
            Checkout.Scan('C');
            Checkout.Scan('A');

            Assert.That(Checkout.GetTotalPrice(), Is.EqualTo(130 + 30 + 20 + 20));
        }
    }
}
