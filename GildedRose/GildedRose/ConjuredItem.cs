namespace GildedRose;

public class ConjuredItem : Item
{
    public override void UpdateQuality()
    {
        ReduceQuality(2);
        SellIn--;
        if (SellIn < 0)
            ReduceQuality(2);
    }
}