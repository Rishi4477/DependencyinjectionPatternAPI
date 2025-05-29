using System;
using System.Collections.Generic;

namespace EntityFrameWork.Entities;

public partial class Newregistration
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;
}
