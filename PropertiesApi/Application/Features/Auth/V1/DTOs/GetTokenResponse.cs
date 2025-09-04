namespace PropertiesApi.Application.Features.Auth.V1.DTOs
{
    public class GetTokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
