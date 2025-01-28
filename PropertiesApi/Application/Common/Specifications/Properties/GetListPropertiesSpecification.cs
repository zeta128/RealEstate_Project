using Ardalis.Specification;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertiesApi.Domain.Options.Pagination;
using PropertiesApi.Domain.Entities;
using Property = PropertiesApi.Domain.Entities.Property;
using PropertiesApi.Domain.DTOs;
using PropertiesApi.Domain.Enums;


namespace PropertiesApi.Application.Common.Specifications.Properties
{
    public class GetListPropertiesSpecification : Specification<Property>
    {


        public GetListPropertiesSpecification(int? numberPage, int? numberRows, List<FilterDto> filters, string fieldOrder = "", string sortDirection = "")
        {
            Query.Include(v => v.Owner);

            var name = filters.Where(x => x.FieldFilter.ToLower().Equals("name")).FirstOrDefault();
            var address = filters.Where(x => x.FieldFilter.ToLower().Equals("address")).FirstOrDefault();
            var priceGreaterThan = filters.Where(x => x.FieldFilter.ToLower().Equals("pricegreaterthan")).FirstOrDefault();
            var priceLessThan = filters.Where(x => x.FieldFilter.ToLower().Equals("pricelessthan")).FirstOrDefault();
            var codeInternal = filters.Where(x => x.FieldFilter.ToLower().Equals("codeinternal")).FirstOrDefault();
            var yearGreaterThan = filters.Where(x => x.FieldFilter.ToLower().Equals("yeargreaterthan")).FirstOrDefault();
            var yearLessThan = filters.Where(x => x.FieldFilter.ToLower().Equals("yearlessthan")).FirstOrDefault();
            var Owner = filters.Where(x => x.FieldFilter.ToLower().Equals("idowner")).FirstOrDefault();


            if (!string.IsNullOrEmpty(name?.ValueFilter))
            {
                Query.Where(x => x.Name!.Equals(name.ValueFilter));
            }
            if (!string.IsNullOrEmpty(address?.ValueFilter))
            {
                Query.Where(x => x.Address.Equals(address.ValueFilter));
            }
            if (!string.IsNullOrEmpty(priceGreaterThan?.ValueFilter))
            {
                Query.Where(x => x.Price >= decimal.Parse(priceGreaterThan.ValueFilter));
            }
            if (!string.IsNullOrEmpty(priceLessThan?.ValueFilter))
            {
                Query.Where(x => x.Price <= decimal.Parse(priceLessThan.ValueFilter));
            }
            if (!string.IsNullOrEmpty(codeInternal?.ValueFilter))
            {
                Query.Where(x => x.CodeInternal == codeInternal.ValueFilter);
            }
            if (!string.IsNullOrEmpty(Owner?.ValueFilter))
            {
                Query.Where(x => x.IdOwner == long.Parse(Owner.ValueFilter));
            }
            if (!string.IsNullOrEmpty(yearGreaterThan?.ValueFilter))
            {
                if (DateOnly.TryParse(yearGreaterThan.ValueFilter, out DateOnly yearG))
                {
                    Query.Where(x => x.Year >= yearG);
                }
            }
            if (!string.IsNullOrEmpty(yearLessThan?.ValueFilter))
            {
                if (DateOnly.TryParse(yearLessThan.ValueFilter, out DateOnly yearL))
                {
                    Query.Where(x => x.Year <= yearL);
                }
            }


            if (!string.IsNullOrEmpty(fieldOrder) && !fieldOrder.ToLower().Equals(ValuesByDefaultEnum.IdOwner.ToString()))
            {
                Query.OrderBy(fieldOrder, sortDirection);
            }
            else
            {
                Query.OrderBy(ValuesByDefaultEnum.address.ToString(), ValuesByDefaultEnum.desc.ToString());
            }
            var numeroFilas = numberRows ?? ValuesByDefaultPaged.NumberFiles_ByDefault;
            Query.Skip(((numberPage ?? ValuesByDefaultPaged.NumberPage_ByDefault) - 1) * numeroFilas).Take(numeroFilas);
        }
    }
}
