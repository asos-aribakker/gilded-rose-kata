using NUnit.Framework;

namespace GildedRose;

[TestFixture]
public class ItemShould
{
    [Test]
    public void ReduceQualityByTwoWhenPastSellInDate()
    {
        Item item = new Item { Name = "foo", SellIn = 0, Quality = 10 };
        item.UpdateQuality();
        Assert.AreEqual(8, item.Quality);
    }
    
    [Test]
    public void ReduceQualityByOneWhenNotPastSellInDate()
    {
        Item item = new Item { Name = "foo", SellIn = 10, Quality = 10 };
        item.UpdateQuality();
        Assert.AreEqual(9, item.Quality);
    }
}