using Ardalis.GuardClauses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using System;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreatePropertyImage
{
    public class CreatePropertyImageCommand : IRequest<BaseResponse<string>>
    {
        public long IdProperty { get; set; }
        public string? UrlImage { get; set; }


        public CreatePropertyImageCommand(
            long idProperty,
            string? urlImage
           )
        {
            IdProperty = idProperty;
            UrlImage = urlImage;
        }

    }
}
