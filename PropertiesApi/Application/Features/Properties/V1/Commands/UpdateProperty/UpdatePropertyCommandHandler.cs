
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;

namespace PropertiesApi.Application.Features.Owners.V1.Commands.UpdateProperty
{
    public class UpdatePropertyCommandHandler(IUnitOfWork unitOfWork
        )
        : IRequestHandler<UpdatePropertyCommand, BaseResponse<String>>
    {
        
        public async Task<BaseResponse<String>> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var updateProperty = await UpdateProperty(request);
          
            return  new BaseResponse<String>(updateProperty.IdProperty.ToString(),"");
        }

        /// <summary>
        /// Updates an existing property in the system with the provided data.
        /// </summary>
        /// <param name="request">An object containing the necessary data to update the property.</param>
        /// <returns>Returns the updated property with the new information.</returns>
        private async Task<Property> UpdateProperty(UpdatePropertyCommand request)
        {
            Property propertyFind = await unitOfWork._propertyRepository.GetByIdAsync(request.IdProperty);
            if (propertyFind != null)
            {
                propertyFind.Price = request.Price;
                propertyFind.CodeInternal = request.CodeInternal;
                propertyFind.IdOwner = request.IdOwner!.Value;
            }
            
            await unitOfWork._propertyRepository.UpdateAsync(propertyFind);
            await unitOfWork.SaveChangesAsync();
            return propertyFind;
        }
        

    }
}