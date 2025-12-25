using System;
using System.Collections.Generic;

namespace DbCoreWebApi.EF.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Salary { get; set; }
}
