using System;
using System.Collections.Generic;

namespace mvvm.Models;

public partial class Tblcategory
{
    public int Id { get; set; }

    public string? Category { get; set; }

    public virtual ICollection<Tblproduct> Tblproducts { get; } = new List<Tblproduct>();
}
