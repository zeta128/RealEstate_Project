using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common;


namespace PropertiesApi.Application.Features.Owners.V1.Commands.UpdateProperty
{
    public class UpdatePropertyEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}update-property", async (UpdatePropertyCommand datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Properties.Tag)
            .RequireAuthorization();
        }
    }
}
