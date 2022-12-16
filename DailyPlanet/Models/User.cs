using System;
using System.Collections.Generic;

namespace DailyPlanet.Models;

public partial class User
{
    public string Email { get; set; } = null!;

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? AccountId { get; set; }
}
