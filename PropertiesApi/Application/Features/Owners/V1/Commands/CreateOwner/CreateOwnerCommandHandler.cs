using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.CreateOwner
{
  
    public class CreateOwnerCommandHandler(IUnitOfWork unitOfWork
        )
        : IRequestHandler<CreateOwnerCommand, BaseResponse<String>>
    {
      
        public async Task<BaseResponse<String>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var newOwner = await RegisterOwner(request);
            await unitOfWork.SaveChangesAsync();     
            return  new BaseResponse<String>(newOwner.IdOwner.ToString(),"Owner creation is done");

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
             var ownerProperty = await unitOfWork._ownerPropertyRepository.AddAsync(newOwner);
            return ownerProperty;
        }

    }
}