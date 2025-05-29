using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    public class ProductsModel
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public double? Price { get; set; }

    }
}
