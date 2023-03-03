namespace GildedRose;

public class BackstagePassItem : Item
{
    public override void UpdateQuality()
    {
        switch (SellIn)
        {
            case < 6:
                IncreaseQuality(3);
                break;
            case < 11:
                IncreaseQuality(2);
                break;
            default:
                IncreaseQuality(1);
                break;
        }

        DecreaseSellIn();
        
        if (SellIn < 0)
        {
            Quality = MinQuality;
        }
    }
}