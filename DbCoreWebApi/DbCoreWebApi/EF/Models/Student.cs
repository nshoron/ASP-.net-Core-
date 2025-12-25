using System;
using System.Collections.Generic;

namespace DbCoreWebApi.EF.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }
}
