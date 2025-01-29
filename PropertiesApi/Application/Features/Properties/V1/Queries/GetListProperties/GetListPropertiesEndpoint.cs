using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common;


namespace PropertiesApi.Application.Features.Owners.V1.Queries.GetListProperties
{
    public class GetListPropertiesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}get-list-properties", async (GetListPropertiesQuery datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Properties.Tag)
            .WithDescription("<b>Filters:</b></br> " +
            "Name, Address, CodeInternal, IdOwner, </br>" +
            "priceGreaterThan (Specify that the price must be greater than the given value),</br> " +
            "priceLessThan (Specify that the price must be less than the given value), </br>" +
            "yearGreaterThan (Specify that the year must be greater than the given value), </br>" +
            "yearLessThan (Specify that the year must be less than the given value) </br></br>"+
            "<b>Sorts:</b></br>"+
            "Name, Address, Price, CodeInternal, Year")
            .WithSummary("Get a list of properties paginated by filters and sorts")
            .RequireAuthorization();
        }
    }
}
