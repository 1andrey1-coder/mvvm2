using System;
using System.Collections.Generic;
using mvvm.OtherFiles;

namespace mvvm.Models;

public partial class TblProvider
{
    public int Id { get; set; }

    public string? Provider { get; set; }

    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();
}
