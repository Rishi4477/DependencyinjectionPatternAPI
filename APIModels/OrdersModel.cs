using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    public class OrdersModel
    {
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        public int? EmployeeId { get; set; }

        public DateOnly? OrderDate { get; set; }

        public int? ShipperId { get; set; }

    }
}
