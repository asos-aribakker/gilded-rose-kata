using System.Runtime.CompilerServices;

namespace GildedRose
{
    public class GildedRose
    {
        private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasName = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrieName = "Aged Brie";
        private const int MaxQuality = 50;
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                item.UpdateQuality();
                
                // if(1=0)
                // {
                //     UpdateItemQuality(item);
                //
                //     UpdateSellIn(item);        
                // }
            }
        }

        private void UpdateSellIn(Item item)
        {
            if (item.Name != SulfurasName)
            {
                item.SellIn--;
            }

            if (item.SellIn >= 0)
                return;

            UpdateQualityWhenPastSellIn(item);
        }

        private void UpdateItemQuality(Item item)
        {
            if (item.Name == SulfurasName)
                return;
            
            if (ShouldDecreaseQuality(item))
            {
                item.Quality--;
            }
            else
            {
                IncreaseQuality(item);
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality >= MaxQuality) 
                return;
            
            item.Quality++;

            if (!IsBackstagePass(item)) 
                return;
            
            if (item is { SellIn: < 11, Quality: < MaxQuality })
            {
                item.Quality++;
            }

            if (item is { SellIn: < 6, Quality: < MaxQuality })
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

            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }

        private bool ShouldDecreaseQuality(Item item)
        {
            return IsNonStandardItem(item) && item.Quality > 0;
        }
        
        private bool IsNonStandardItem(Item item)
        {
            return item.Name != AgedBrieName && !IsBackstagePass(item);
        }

        private bool IsBackstagePass(Item item)
        {
            return item.Name == BackstagePassName;
        }
    }
}
