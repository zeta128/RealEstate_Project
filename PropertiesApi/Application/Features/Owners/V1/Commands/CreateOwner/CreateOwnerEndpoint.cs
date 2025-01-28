using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertiesApi.Application.Common;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateOwner
{
    /// <summary>
    /// Maneja la creación de un nuevo propietario.
    /// </summary>
    /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
    /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
    /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
    /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
    /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
    public class CreateOwnerEndpoint: ICarterModule
    {
        /// <summary>
        /// Maneja la creación de un nuevo propietario.
        /// </summary>
        /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
        /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
        /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
        /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            /// <summary>
            /// Maneja la creación de un nuevo propietario.
            /// </summary>
            /// <param name="request">El comando que contiene la información necesaria para crear un propietario.</param>
            /// <param name="cancellationToken">El token de cancelación para abortar la operación si es necesario.</param>
            /// <returns>Un <see cref="Task"/> que representa la operación asincrónica. El resultado contiene los detalles del propietario creado.</returns>
            /// <exception cref="ArgumentNullException">Se lanza si el comando es nulo.</exception>
            /// <exception cref="Exception">Se lanza si ocurre un error durante la creación del propietario.</exception>
            app.MapPost($"{Tags.RutaVersionUno}create-owner", async (CreateOwnerCommand datos, ISender sender) =>
            {
                return Results.Ok(await sender.Send(datos));
            }).WithTags(Tags.Owners.Tag)
            .RequireAuthorization();
        }
    }
}
