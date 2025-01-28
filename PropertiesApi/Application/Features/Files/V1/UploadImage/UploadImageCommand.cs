using Ardalis.GuardClauses;
using MediatR;
using PropertiesApi.Application.Common.Wrappers;

namespace PropertiesApi.Application.Features.Files.V1.UploadImage
{
    public class UploadImageCommand : IRequest<BaseResponse<string>>
    {     
        public string? NamePhoto { get; set; }

        public byte[] PhotoContent { get; set; }


        //public UploadImageCommand(        
        //    string? urlPhoto,
        //    byte[] photoContent
        //   )
        //{        
        //    NamePhoto = urlPhoto;
        //    PhotoContent = photoContent;
        //}
    }
}
