namespace Auth.App.Services
{
    public interface ITokenGenerator
    {
        Task<string> GenerateTokenAsync(string name, string surname, string email, string phone, bool longExpired = false);
    }
}
