namespace Angular_BE_API.ViewModels
{
    public record LoginResultViewModel(bool IsSuccess, string Token, string ErrorMessage = "");
}
