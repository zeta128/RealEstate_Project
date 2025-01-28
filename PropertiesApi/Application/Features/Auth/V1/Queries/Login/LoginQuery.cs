using Ardalis.GuardClauses;
using MediatR;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Auth.V1.Queries.Login;
using PropertiesApi.Domain.Options.Pagination;

namespace PropertiesApi.Application.Features.Auth.V1.Commmands.Login
{
    public class LoginQuery(string username, string password) : IRequest<BaseResponse<LoginResponse>>
    {
        public string Username { get; set; } = Guard.Against.NullOrEmpty(username, "username", "this field cannot be empty");
        public string Password { get; set; } = Guard.Against.NullOrEmpty(password, "password", "this field cannot be empty");
    }
}