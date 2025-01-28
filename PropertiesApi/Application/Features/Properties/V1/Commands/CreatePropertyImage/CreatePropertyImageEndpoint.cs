using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreatePropertyImage
{
    public class CreatePropertyImageEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}create-property-image", async (CreatePropertyImageCommand datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Properties.Tag)
            .RequireAuthorization();
        }
    }
}
