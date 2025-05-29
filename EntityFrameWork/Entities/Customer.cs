using System;
using System.Collections.Generic;

namespace EntityFrameWork.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? ContactName { get; set; }

    public string? CoustmerAddress { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? States { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
