using System;
using System.Collections.Generic;

namespace PropertiesApi.Domain.Entities;

public partial class Property
{
    public long IdProperty { get; set; }

    public string? Name { get; set; }

    public string Address { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? CodeInternal { get; set; }

    public DateOnly? Year { get; set; }

    public long IdOwner { get; set; }

    public virtual OwnerProperty IdOwnerNavigation { get; set; } = null!;
}
