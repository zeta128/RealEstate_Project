using System;
using System.Collections.Generic;

namespace PropertiesApi.Domain.Entities;

public partial class OwnerProperty
{
    public long IdOwner { get; set; }

    public string FullName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Photo { get; set; }

    public DateOnly? Birthday { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
