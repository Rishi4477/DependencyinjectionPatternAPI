using System;
using System.Collections.Generic;

namespace EntityFrameWork.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public DateTime? LoginTimeDate { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsEmployee { get; set; }
}
