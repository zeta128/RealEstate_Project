namespace PropertiesApi.Domain.Options;

    public class AppSettings
    {
        public const string SectionKey = "REAL_ESTATE_CONNECTIONSTRING";
        public required string DefaultConnection {  get; set; } 
    }

