using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
