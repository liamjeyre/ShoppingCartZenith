using ShoppingCartZenith.ItemPricingRules;

namespace ShoppingCartZenith.tests
{
    internal class ItemPricingRuleTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void TestItemPricingWithSpecifiedQuantityOf1()
        {
            var itemPricingRule = new ItemPricingRule('A', 1, 20);
            Assert.Multiple(() =>
            {
                Assert.That(itemPricingRule.SKU, Is.EqualTo('A'));
                Assert.That(itemPricingRule.Quantity, Is.EqualTo(1));
                Assert.That(itemPricingRule.Price, Is.EqualTo(20));
            });
        }

        [Test]
        public void TestItemPricingWithSpecifiedQuantityOf3()
        {
            var itemPricingRule = new ItemPricingRule('A', 3, 50);
            Assert.Multiple(() =>
            {
                Assert.That(itemPricingRule.SKU, Is.EqualTo('A'));
                Assert.That(itemPricingRule.Quantity, Is.EqualTo(3));
                Assert.That(itemPricingRule.Price, Is.EqualTo(50));
            });

        }
    }
}
