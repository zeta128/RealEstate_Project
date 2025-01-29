using System;
using System.Collections.Generic;

namespace PropertiesApi.Domain.Entities;

public partial class PropertyTrace
{
    public long IdPropertyTrace { get; set; }

    public DateOnly? DateSale { get; set; }

    public string? Name { get; set; }

    public decimal? Value { get; set; }

    public decimal? Tax { get; set; }

    public long IdProperty { get; set; }

    public virtual Property IdPropertyNavigation { get; set; } = null!;
}
