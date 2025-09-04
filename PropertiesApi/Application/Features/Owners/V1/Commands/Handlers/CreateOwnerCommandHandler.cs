using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Infraestructure.Repositories.Contracts;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.Handlers
{

    public class CreateOwnerCommandHandler(IUnitOfWork unitOfWork, IOwnerRepository ownerRepository
        )
        : IRequestHandler<CreateOwnerCommand, BaseResponse<string>>
    {

        public async Task<BaseResponse<string>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var newOwner = await RegisterOwner(request);
            await unitOfWork.SaveChangesAsync();
            return new BaseResponse<string>("id:"+ newOwner.IdOwner.ToString(), "Owner creation is done");

        }

        /// <summary>
        /// Registers a new owner in the system with the provided data.
        /// </summary>
        /// <param name="request">An object containing the necessary data to register the owner.</param>
        /// <returns>Returns the registered owner with the associated information.</returns>
        private async Task<OwnerProperty> RegisterOwner(CreateOwnerCommand request)
        {
            OwnerProperty newOwner = new OwnerProperty();
            newOwner.FullName = request.FullName;
            newOwner.Address = request.Address;
            newOwner.Photo = request.UrlPhoto;
            newOwner.Birthday = request.Birthday;
            await ownerRepository.CreateOwnerPropertyAsync(newOwner);
            return newOwner;
        }

    }
}