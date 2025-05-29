using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{
    public class UsersModel
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public DateTime? LoginTimeDate { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsEmployee { get; set; }
    }
}
