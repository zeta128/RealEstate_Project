using Ardalis.GuardClauses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using System;
using System.Net;

namespace PropertiesApi.Application.Features.Properties.V1.Commands
{
    public class CreatePropertyImageCommand : IRequest<BaseResponse<string>>
    {
        public long IdProperty { get; set; }
        public string UrlImage { get; set; }


        public CreatePropertyImageCommand(
            long idProperty,
            string urlImage
        )
        {
            IdProperty = Guard.Against.NegativeOrZero(idProperty, nameof(idProperty), "The id property cannot be empty");
            UrlImage = Guard.Against.NullOrEmpty(urlImage, nameof(urlImage), "The url image cannot be empty");
        }

    }
}
