using Carter;
using MediatR;
using PropertiesApi.Application.Common;


namespace PropertiesApi.Application.Features.Files.V1.UploadImage
{
    public class UploadImageEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost($"{Tags.RutaVersionUno}upload-image", async (UploadImageCommand datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Files.Tag)
             .WithDescription
             ("NamePhoto (Specify the name for a image),</br> "+
             "PhotoContent (Specify the content image to upload in base 64 format)")
             .WithSummary("Load an image in base 64 format and return a url of that image in cloud storage")
            //.RequireAuthorization()
            ;
        }
    }
}
