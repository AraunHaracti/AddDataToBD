using System;
using System.Collections.Generic;

namespace AddDataToBD2;

public partial class Module
{
    public int ModuleId { get; set; }

    public int ProjectId { get; set; }

    public string NameModule { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
