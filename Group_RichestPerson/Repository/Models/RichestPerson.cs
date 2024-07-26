using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class RichestPerson
{
    public int RichestPersonId { get; set; }

    public int? Rank { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public decimal? NetWorth { get; set; }

    public int? CountryId { get; set; }

    public int? IndustryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Industry? Industry { get; set; }
}
