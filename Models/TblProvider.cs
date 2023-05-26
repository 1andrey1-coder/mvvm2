using System;
using System.Collections.Generic;

namespace mvvm.Models;

public partial class Tblprovider
{
    public int Id { get; set; }

    public string? Provider { get; set; }

    public virtual ICollection<Tblproduct> Tblproducts { get; } = new List<Tblproduct>();
}
