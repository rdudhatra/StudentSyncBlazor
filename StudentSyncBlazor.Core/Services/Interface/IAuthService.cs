

using StudentSyncBlazor.Core.Wrapper;
using StudentSyncBlazor.Data.ViewModels;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface IAuthService
    {
        Task<IResult> RegisterAsync(RegisterViewModel model);
        Task<IResult> LoginAsync(LoginViewModel model);
        Task<IResult> LogoutAsync();
        Task<IResult> AdminLoginAsync(LoginViewModel model); // New method for admin login
        Task<string> GetTokenAsync();


    }
}
 