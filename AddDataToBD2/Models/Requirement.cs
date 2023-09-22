using System;
using System.Collections.Generic;

namespace AddDataToBD2;

public partial class Requirement
{
    public int RequirementsId { get; set; }

    public int ModuleId { get; set; }

    public string? Description { get; set; }

    public virtual Module Module { get; set; } = null!;
}
