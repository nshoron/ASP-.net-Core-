using System;
using System.Collections.Generic;

namespace DbCoreWebApi.EF.Models;

public partial class Registration
{
    public int Id { get; set; }

    public string? Status { get; set; }
}
