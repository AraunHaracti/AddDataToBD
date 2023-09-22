using System;
using System.Collections.Generic;

namespace AddDataToBD2;

public partial class Project
{
    public int ProjectId { get; set; }

    public string NameProject { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}
