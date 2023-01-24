using System;
using System.Collections.Generic;

namespace EHOP.Models;

public partial class Buyer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
