using System;
using System.Collections.Generic;

namespace DbCoreWebApi.EF.Models;

public partial class Course
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? Credit { get; set; }
}
