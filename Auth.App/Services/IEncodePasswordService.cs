namespace Auth.App.Services
{
    public interface IEncodePasswordService
    {
        Task<string> EncodePasswordAsync(string? password);
        Task<string> DecodePasswordAsync(string? password);
    }
}
