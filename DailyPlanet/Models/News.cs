using System;
using System.Collections.Generic;

namespace DailyPlanet.Models;

public partial class News
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    public DateTime? Datetime { get; set; }
}
