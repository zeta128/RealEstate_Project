using Ardalis.GuardClauses;
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Auth.V1.Queries.Login;
using PropertiesApi.Domain.Options.Pagination;

namespace PropertiesApi.Application.Features.Auth.V1.Commmands.Login
{
    public class LoginQuery() : IRequest<BaseResponse<LoginResponse>>
    {
      
    }
}