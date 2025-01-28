namespace PropertiesApi.Application.Features.Auth.V1.Queries.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
