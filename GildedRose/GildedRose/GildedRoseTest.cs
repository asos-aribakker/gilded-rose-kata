using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void ShouldReturnFooWhenItemNameIsFoo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(20)]
        public void ShouldLowerSellInDate(int days)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = days, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(days - 1, Items[0].SellIn);
        }
        
        [Test]
        public void ShouldReturnQualityOfZeroWhenStartingQualityIsZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        
        [Test]
        [TestCase(10)]
        [TestCase(20)]
        public void ShouldLowerQualityByTwo(int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(quality - 2, Items[0].Quality);
        }
        
        [Test]
        [TestCase(10)]
        [TestCase(20)]
        public void ShouldIncreaseQualityByTwoWhenNameIsAgedBrie(int quality)
        {
            IList<Item> Items = new List<Item> { new AgedBrieItem { Name = "Aged Brie", SellIn = 0, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(quality + 2, Items[0].Quality);
        }
    }
}
