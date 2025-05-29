using System;
using System.Collections.Generic;

namespace EntityFrameWork.Entities;

public partial class Category
{
    public string? CategoryName { get; set; }

    public string? Descriptions { get; set; }

    public int CategoryId { get; set; }
}
