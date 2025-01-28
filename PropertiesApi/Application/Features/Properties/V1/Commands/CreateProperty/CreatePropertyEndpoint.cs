using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common;


namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateProperty
{
    public class CreatePropertyEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}create-property", async (CreatePropertyCommand datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Properties.Tag)
            .RequireAuthorization().WithDisplayName("display Name").WithSummary("summary").WithTags("tags").WithName("name").WithMetadata("metadata");
        }
    }
}
