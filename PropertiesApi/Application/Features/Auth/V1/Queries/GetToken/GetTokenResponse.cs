namespace PropertiesApi.Application.Features.Auth.V1.Queries.GetToken
{
    public class GetTokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
