using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Catalog.Core.Domain.Models.Models
{
    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeID { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandID { get; set; }
    }
}
