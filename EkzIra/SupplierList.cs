using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkzIra
{
    class SupplierList
    {
        public static SupplierList _instance;
        public List<Supplier> Suppliers;

        public SupplierList()
        {
            var gline = MaterialsList.Instance.Materials.First(m => m.Name == "Глина");
            var perlit = MaterialsList.Instance.Materials.First(m => m.Name == "Перлит");

            Suppliers = new List<Supplier>();

            Suppliers.Add(new Supplier
            {
                Name = "БрянскСтройресурс",
                Rate = 8,
                Date = "20.12.2015",
                Materials = new List<Material> { gline }
            });

            Suppliers.Add(new Supplier
            {
                Name = "ГорТехРазработка",
                Rate = 9,
                Date = "27.12.2021",
                Materials = new List<Material> { gline }
            });

            Suppliers.Add(new Supplier
            {
                Name = "МосКарьер",
                Rate = 2,
                Date = "07.07.2012",
                Materials = new List<Material> { perlit }
            });
        }


        public static SupplierList Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new SupplierList();
                }
                return _instance;
            }
        }
    }
}
