using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkzIra
{
    class MaterialsList
    {
        private static MaterialsList instance;
        public List<Material> Materials  { get; private set; }

        public MaterialsList()
        {
            Materials = new List<Material>();
        }

        public static MaterialsList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MaterialsList();
                }
                return instance;
            }
        }

        public void AddMaterial(string type, string name, int minQuantity, int stockQuantity, double cost, string measure)
        {
            Materials.Add(new Material
            {
                Type = type,
                Name = name,
                MinQuantity = minQuantity,
                StockQuantity = stockQuantity,
                Cost = cost,
                Measure = measure
            });
        }
    }
}
