using Azure;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Application.Features.Auth.V1.Queries.GetToken;
using PropertiesApi.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PropertiesApi.Application.Features.Auth.V1.Commmands.GetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, BaseResponse<GetTokenResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration _configuration;

        public GetTokenQueryHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            _configuration = configuration; 
        }

        public async Task<BaseResponse<GetTokenResponse>> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            GetTokenResponse loginResponse = GenerateToken("test");
            return new BaseResponse<GetTokenResponse>(loginResponse); 
        }
        public GetTokenResponse GenerateToken(string username)
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

            return new GetTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
 }
