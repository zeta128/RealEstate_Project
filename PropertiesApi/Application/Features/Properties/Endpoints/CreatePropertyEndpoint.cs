using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common;
using PropertiesApi.Application.Features.Properties.V1.Commands;

namespace PropertiesApi.Application.Features.Properties.Endpoints
{
    public class CreatePropertyEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}create-property", async (CreatePropertyCommand datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Properties.Tag)
            .WithSummary("Creates a property based on the provided input values.")
            .WithDescription("<b>The parameters address and idowner are required.<b/>")
            .RequireAuthorization();
        }
    }
}
