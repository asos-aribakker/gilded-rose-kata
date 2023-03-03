namespace GildedRose
{
    public class Item
    {
        protected const int MaxQuality = 50;
        protected const int MinQuality = 0;
        
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public virtual void UpdateQuality()
        {
            ReduceQuality(1);
            SellIn--;
            if (SellIn < 0)
                ReduceQuality(1);
        }

        protected void DecreaseSellIn()
        {
            SellIn--;
        }
        
        protected void ReduceQuality(int increment)
        {
            Quality -= increment;

            if (Quality < MinQuality)
                Quality = MinQuality;
        }
        
        protected void IncreaseQuality(int increment)
        {
            Quality += increment;

            if (Quality > MaxQuality)
                Quality = MaxQuality;
        }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
