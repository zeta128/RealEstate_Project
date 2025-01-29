using Ardalis.GuardClauses;
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Auth.V1.Queries.GetToken;

namespace PropertiesApi.Application.Features.Auth.V1.Commmands.GetToken
{
    public class GetTokenQuery() : IRequest<BaseResponse<GetTokenResponse>>
    {
      
    }
}