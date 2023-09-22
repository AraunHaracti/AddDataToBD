using System;
using System.Collections.Generic;

namespace AddDataToBD2;

public partial class Task
{
    public int TaskId { get; set; }

    public int ModuleId { get; set; }

    public string NameTask { get; set; } = null!;

    public string? Description { get; set; }

    public int EmployeeId { get; set; }

    public int StatusId { get; set; }

    public DateOnly? DateOfStart { get; set; }

    public DateOnly? DateOfFinish { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
