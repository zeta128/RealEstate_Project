using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateOwner
{  
    public class CreateOwnerEndpoint: ICarterModule
    {    
        public void AddRoutes(IEndpointRouteBuilder app)
        {          
            app.MapPost($"{Tags.RutaVersionUno}create-owner", async (CreateOwnerCommand datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Owners.Tag)
            .WithSummary("Create an owner")
            .WithDescription("<b>The parameter fullName is required</b></br>" +
            "Return in data de id of owner" )
            .RequireAuthorization();
        }
    }
}
