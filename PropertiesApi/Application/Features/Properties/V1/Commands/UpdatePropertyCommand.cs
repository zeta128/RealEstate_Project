using Ardalis.GuardClauses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using System;

namespace PropertiesApi.Application.Features.Properties.V1.Commands
{
    public class UpdatePropertyCommand : IRequest<BaseResponse<string>>
    {
        public long IdProperty { get; set; }
        public decimal? Price { get; set; }

        public string? CodeInternal { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public long? IdOwner { get; set; }


        public UpdatePropertyCommand(
            long idProperty,
            decimal? price,
            string? codeInternal,
            string? name,
            string? address,
            long? idOwner
           )
        {
            IdProperty = Guard.Against.NegativeOrZero(idProperty, nameof(idProperty), "The address of property cannot be empty");
            Price = price;
            CodeInternal = codeInternal;
            Name = name;
            Address = address;
            IdOwner = idOwner;
        }

    }
}
