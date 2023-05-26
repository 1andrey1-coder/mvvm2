using System;
using System.Collections.Generic;
using mvvm.OtherFiles;

namespace mvvm.Models;

public partial class TblProduct
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Category { get; set; }

    public int? ProviderId { get; set; }

    public int? CostOfOne { get; set; }

    public string? Discount { get; set; }

    public virtual TblCategory? CategoryNavigation { get; set; }

    public virtual TblProvider? Provider { get; set; }
}
