namespace GildedRose;

public class SulfurasItem : Item
{
    public override void UpdateQuality()
    {
        DecreaseSellIn();
    }
}