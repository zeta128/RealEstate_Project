using Azure;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Auth.V1.Queries.Login;
using PropertiesApi.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PropertiesApi.Application.Features.Auth.V1.Commmands.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, BaseResponse<LoginResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration _configuration;

        public LoginQueryHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            _configuration = configuration; 
        }

        public async Task<BaseResponse<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            LoginResponse loginResponse = GenerateToken("test");
            return new BaseResponse<LoginResponse>(loginResponse); 
        }
        public LoginResponse GenerateToken(string username)
        {
            var secretKey = _configuration["Jwt:SecretKey"]!;
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Claims: Puedes agregar más información aquí según sea necesario.
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "User") // Puedes agregar roles dinámicos.
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials
            );

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
 }
