using System;

namespace EkzIra
{
    public class Material
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int MinQuantity { get; set; }
        public int StockQuantity { get; set; }
        public double Cost { get; set; }
        public string Measure { get; set; }
        public int QuantityInWrapper {  get; set; }
        public double AcqCost
        {
            get
            {
                if (StockQuantity < MinQuantity)
                {
                    int lack = MinQuantity - StockQuantity;
                    int wrappers = (int)Math.Ceiling((double)lack / QuantityInWrapper);
                    double total = Convert.ToInt32(Math.Round(wrappers * QuantityInWrapper * Cost, 2));
                    return total;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
