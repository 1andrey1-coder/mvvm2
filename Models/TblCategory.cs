using System;
using mvvm.OtherFiles;
using System.Collections.Generic;


namespace mvvm.Models;

public partial class TblCategory
{
    public int Id { get; set; }

    public string? Category { get; set; }

    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();
}
