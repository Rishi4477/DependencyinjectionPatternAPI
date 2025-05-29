using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    public class EmployeesModel
    {
        public int EmployeeId { get; set; }

        public string? LastName { get; set; }
         
        public string? FirstName { get; set; }

        public string? Notes { get; set; }
        public string? Photo { get; set; }


    }
}
