namespace GildedRose
{
    public class GildedRose
    {
        private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasName = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrieName = "Aged Brie";
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            { 
                var item = Items[i];
                
                if (ShouldDecreaseQuality(item))
                {
                    item.Quality--;
                }
                else
                {
                    IncreaseQuality(item);
                }

                if (item.Name != SulfurasName)
                {
                    item.SellIn--;
                }

                if(item.SellIn >= 0)
                    continue;

                UpdateQualityWhenPastSellIn(item);
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality >= 50) 
                return;
            item.Quality++;

            if (!IsBackstagePass(item)) 
                return;
            
            if (item is { SellIn: < 11, Quality: < 50 })
            {
                item.Quality++;
            }

            if (item is { SellIn: < 6, Quality: < 50 })
            {
                item.Quality++;
            }
        }

        private void UpdateQualityWhenPastSellIn(Item item)
        {
            if (item.Name != AgedBrieName)
            {
                if (IsBackstagePass(item))
                {
                    item.Quality -= item.Quality;
                    return;
                }

                if (item.Quality <= 0)
                {
                    return;
                }

                if (item.Name != SulfurasName)
                {
                    item.Quality--;
                }

                return;
            }

            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private bool ShouldDecreaseQuality(Item item)
        {
            return IsNonStandardItem(item) && item.Quality > 0;
        }

        private bool IsStandardItem(Item item)
        {
            return !IsNonStandardItem(item);
        }
        
        private bool IsNonStandardItem(Item item)
        {
            return item.Name != AgedBrieName && !IsBackstagePass(item) && item.Name != SulfurasName;
        }

        private bool IsBackstagePass(Item item)
        {
            return item.Name == BackstagePassName;
        }
    }
}
