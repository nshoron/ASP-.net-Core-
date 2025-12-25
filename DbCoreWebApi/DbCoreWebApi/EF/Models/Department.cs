using System;
using System.Collections.Generic;

namespace DbCoreWebApi.EF.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
