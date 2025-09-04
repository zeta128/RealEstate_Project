using Carter;
using MediatR;
using PropertiesApi.Application.Common;
using PropertiesApi.Application.Features.Auth.V1.Queries;
using System.Text.Json;

namespace PropertiesApi.Application.Features.Auth.Endpoints
{
    public class GetTokenEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}get-token",
            async (HttpContext httpContext, GetTokenQuery request, ISender sender) =>
            {
                var respuesta = await sender.Send(request);

                return Results.Ok(respuesta);
            }).WithTags(Tags.Auth.Tag)
            .WithSummary("Endpoint to get the token")
            .WithDescription("<b>At the moment the endpoint don´t need a username and password, but the login will be configured later</b> ")
            ;
        }
    }
}