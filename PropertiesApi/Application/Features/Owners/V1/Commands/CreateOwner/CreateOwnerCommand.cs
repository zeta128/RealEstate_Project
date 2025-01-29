using Ardalis.GuardClauses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using System;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateOwner
{   
    public class CreateOwnerCommand : IRequest<BaseResponse<string>>
    {
        public string FullName { get; set; } = null!;

        public string? Address { get; set; }

        public string? UrlPhoto { get; set; }

        public DateOnly? Birthday { get; set; }

       
        public CreateOwnerCommand(
            string fullName,
            string? address,
            string? urlPhoto,
            DateOnly? birthday
           )
        {
            FullName = Guard.Against.NullOrEmpty(fullName, nameof(fullName), "The owner´s name cannot be empty"); 
            Address = address;
            UrlPhoto = urlPhoto;
            Birthday = birthday;
        }
    }
}
