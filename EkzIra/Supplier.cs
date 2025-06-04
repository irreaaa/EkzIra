using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkzIra
{
    public class Supplier
    {
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Date { get; set; }
        public List<Material> Materials { get; set; }

       
    }
}
