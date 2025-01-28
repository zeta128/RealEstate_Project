using Ardalis.GuardClauses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using System;
using System.ComponentModel;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateProperty
{
    public class CreatePropertyCommand : IRequest<BaseResponse<string>>
    {
        public string? Name { get; set; } 

        public string Address { get; set; } = null!;

        public decimal? Price { get; set; }

        public string? CodeInternal { get; set; }        

        public DateOnly? Year { get; set; }

        public long IdOwner { get; set; }
        public string? UrlImage { get; set; }


        public CreatePropertyCommand(
            string name,
            string address,
            decimal? price,
            string? codeInternal,
            DateOnly? year,
            long idOwner
           
           )
        {
            Name = name;
            Address = Guard.Against.NullOrEmpty(address, nameof(address), "The address of property cannot be empty");
            Price = price;
            CodeInternal = codeInternal;
            Year = year;
            IdOwner = Guard.Against.NegativeOrZero(idOwner, nameof(idOwner), "The idOwner cannot be empty because is a relational value");

        }

    }
}
