using Carter;
using MediatR;
using PropertiesApi.Application.Common;
using System.Text.Json;

namespace PropertiesApi.Application.Features.Auth.V1.Commmands.Login
{
    public class LoginQueryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}login",
            async (HttpContext httpContext, LoginQuery request, ISender sender) =>
            {
                var respuesta = await sender.Send(request);
      
                return Results.Ok(respuesta);
            }).WithTags(Tags.Login.Tag)
            .WithDescription("<b>Filtros:</b> noresolucion,tiporesolucionid, programaid, procesoid, estadoid, fechacreacion, fechainiciorango, fechafinrango, usuarioid")
            ;
        }
    }
}