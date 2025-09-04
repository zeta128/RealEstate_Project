using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common;
using PropertiesApi.Application.Features.Properties.V1.Commands;

namespace PropertiesApi.Application.Features.Properties.Endpoints
{
    public class UpdatePropertyEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}update-property", async (UpdatePropertyCommand datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Properties.Tag)
            .WithSummary("Update a property based on the provided optional input values.")
            .WithDescription("<b>The parameter idProperty are required, for the rest all are optional.<b/>")
            .RequireAuthorization();
        }
    }
}
