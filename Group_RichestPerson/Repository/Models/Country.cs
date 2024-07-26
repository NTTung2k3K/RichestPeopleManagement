using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<RichestPerson> RichestPeople { get; set; } = new List<RichestPerson>();
}
