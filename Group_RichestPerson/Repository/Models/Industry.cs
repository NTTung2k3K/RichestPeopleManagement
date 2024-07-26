using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Industry
{
    public int IndustryId { get; set; }

    public string? IndustryName { get; set; }

    public virtual ICollection<RichestPerson> RichestPeople { get; set; } = new List<RichestPerson>();
}
