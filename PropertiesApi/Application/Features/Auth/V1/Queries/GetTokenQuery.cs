using Ardalis.GuardClauses;
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Auth.V1.DTOs;

namespace PropertiesApi.Application.Features.Auth.V1.Queries
{
    public class GetTokenQuery() : IRequest<BaseResponse<GetTokenResponse>>
    {

    }
}