using System;
using System.Collections.Generic;

namespace mvvm.Models;

public partial class Tblproduct
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Category { get; set; }

    public int? ProviderId { get; set; }

    public int? CostOfOne { get; set; }

    public string? Discount { get; set; }

    public virtual Tblcategory? CategoryNavigation { get; set; }

    public virtual Tblprovider? Provider { get; set; }
}
