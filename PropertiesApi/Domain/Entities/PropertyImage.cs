using System;
using System.Collections.Generic;

namespace PropertiesApi.Domain.Entities;

public partial class PropertyImage
{
    public long IdPropertyImage { get; set; }

    public long IdProperty { get; set; }

    public string? FileUrl { get; set; }
}
