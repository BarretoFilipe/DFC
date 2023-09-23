namespace DFCApi.Models.Settings
{
    public class TokenSettings
    {
        public string Secret { get; set; } = string.Empty;
        public int ExpiresInHours { get; set; } = int.MinValue;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}