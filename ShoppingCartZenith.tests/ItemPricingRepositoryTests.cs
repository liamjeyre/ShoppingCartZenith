using ShoppingCartZenith.ItemPricingRules.ItemPricingRuleRepository;

namespace ShoppingCartZenith.tests
{
    internal class ItemPricingRepositoryTests
    {
        private ItemPricingRepository itemPricingRepository;

        [SetUp]
        public void Setup()
        {
            itemPricingRepository = new ItemPricingRepository();
        }

        [Test]
        public void RuleIsAddedToRepoUsingAddMethod()
        {
            itemPricingRepository.AddItemPricingRule('A', 1, 10);
            Assert.Multiple(() =>
            {
                Assert.That(itemPricingRepository.Rules[0].SKU, Is.EqualTo('A'));
                Assert.That(itemPricingRepository.Rules[0].Quantity, Is.EqualTo(1));
                Assert.That(itemPricingRepository.Rules[0].Price, Is.EqualTo(10));
            });
        }

        [Test]
        public void MultipleRulesCanBeAddedToRepoUsingAddMethod()
        {
            itemPricingRepository.AddItemPricingRule('A', 1, 10);
            itemPricingRepository.AddItemPricingRule('B', 2, 20);
            itemPricingRepository.AddItemPricingRule('C', 3, 30);
            itemPricingRepository.AddItemPricingRule('D', 4, 40);

            Assert.Multiple(() =>
            {
                Assert.That(itemPricingRepository.Rules[1].SKU, Is.EqualTo('B'));
                Assert.That(itemPricingRepository.Rules[2].Quantity, Is.EqualTo(3));
                Assert.That(itemPricingRepository.Rules[3].Price, Is.EqualTo(40));
            });
        }
    }
}