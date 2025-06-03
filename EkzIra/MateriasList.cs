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
            Materials.Add(new Material
            {
                Type = "Пластичные материалы",
                Name = "Глина",
                MinQuantity = 5500,
                StockQuantity = 1570,
                Cost = 15.29,
                Measure = "кг",
                QuantityInWrapper = 30
            });
            Materials.Add(new Material
            {
                Type = "Добавка",
                Name = "Перлит",
                MinQuantity = 1000,
                StockQuantity = 150,
                Cost = 13.99,
                Measure = "л",
                QuantityInWrapper = 50
            });
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
