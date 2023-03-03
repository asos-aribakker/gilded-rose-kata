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
            ReduceQuality();
            SellIn--;
            if (SellIn < 0)
                ReduceQuality();
        }

        protected void DecreaseSellIn()
        {
            SellIn--;
        }
        
        private void ReduceQuality()
        {
            if(Quality > MinQuality)
                Quality--;
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
