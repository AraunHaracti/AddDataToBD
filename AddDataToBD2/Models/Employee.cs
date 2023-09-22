using System;
using System.Collections.Generic;

namespace AddDataToBD2;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Surname { get; set; }

    public DateOnly? DateOfBorn { get; set; }

    public string? Skills { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
