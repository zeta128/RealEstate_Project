using PropertiesApi.Domain.Entities;
using System.ComponentModel;

namespace PropertiesApi.Application.Features.Properties.V1.Queries.GetListProperties
{
    public class GetListPropertiesResponse
    {
        public long IdProperty { get; set; }

        public string? Name { get; set; }

        public string Address { get; set; } = null!;

        public decimal? Price { get; set; }

        public string? CodeInternal { get; set; }

        public DateOnly? Year { get; set; }
        public string IdOwner { get; set; }

        public string OwnerFullName { get; set; }

       
    }
}
