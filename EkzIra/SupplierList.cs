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

        public SupplierList() {
            Suppliers = new List<Supplier>();
            var supplierMaterial = new List<Material>()
            {
                MaterialsList.Instance.Materials.First(m => m.Name == "Глина"),
                MaterialsList.Instance.Materials.First(m => m.Name == "Перлит")
            };

            Suppliers.Add(new Supplier
            {
                Name = "БрянскСтройресурс",
                Rate = 8,
                Date = "20.12.2015",
                Materials = supplierMaterial
            });

            Suppliers.Add(new Supplier
            {
                Name = "ГорТехРазработка",
                Rate = 9,
                Date = "27.12.2021",
                Materials = supplierMaterial
            });

            Suppliers.Add(new Supplier
            {
                Name = "МосКарьер",
                Rate = 2,
                Date = "07.07.2012",
                Materials = supplierMaterial
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
