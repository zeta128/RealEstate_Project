using Ardalis.GuardClauses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common.Wrappers;
using System;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateOwner
{/// <summary>
 /// Maneja la creación de un nuevo propietario.
 /// </summary>
 /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
 /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
 /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
 /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
 /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
    public class CreateOwnerCommand : IRequest<BaseResponse<string>>
    {
        public string FullName { get; set; } = null!;

        public string? Address { get; set; }

        public string? UrlPhoto { get; set; }

        public DateOnly? Birthday { get; set; }

        /// <summary>
        /// Maneja la creación de un nuevo propietario.
        /// </summary>
        /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
        /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
        /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
        /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
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
