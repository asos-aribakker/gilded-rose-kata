namespace GildedRose;

public class AgedBrieItem : Item
{
    public override void UpdateQuality()
    {
        IncreaseQuality(1);
        
        DecreaseSellIn();
        
        if (SellIn < 0)
        {
            IncreaseQuality(1);
        }
    }
}