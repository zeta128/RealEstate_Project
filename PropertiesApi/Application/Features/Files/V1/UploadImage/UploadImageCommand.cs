using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using System.Text.Json.Serialization;

namespace PropertiesApi.Application.Features.Files.V1.UploadImage
{
    public class UploadImageCommand(string namePhoto, byte[] photoContent) : IRequest<BaseResponse<string>>
    {
        public string NamePhoto { get; set; } = namePhoto;
        public byte[] PhotoContent { get; set; } = photoContent;

    }
}
