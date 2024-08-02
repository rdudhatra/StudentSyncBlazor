using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using StudentSyncBlazor.Core.Services.Interface;
using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ViewModels;
using System.Security.Claims;



public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null || !user.Identity.IsAuthenticated)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        return new AuthenticationState(user);
    }

    public async Task MarkUserAsAuthenticated(string username, string email)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Email, email),
            };

        var claimsIdentity = new ClaimsIdentity(claims, "apiauth_type");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public async Task MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
    }
}
//public class CustomAuthenticationStateProvider : AuthenticationStateProvider
//{
//    private readonly IHttpContextAccessor _httpContextAccessor;

//    public CustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
//    {
//        _httpContextAccessor = httpContextAccessor;
//    }

//    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//    {
//        var user = _httpContextAccessor.HttpContext?.User;
//        if (user == null || !user.Identity.IsAuthenticated)
//        {
//            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
//        }

//        return new AuthenticationState(user);
//    }

//    public async Task MarkUserAsAuthenticated(User user)
//    {
//        var claims = new List<Claim>
//        {
//            new Claim(ClaimTypes.Name, user.Username),
//            new Claim(ClaimTypes.Email, user.Email),
//        };

//        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

//        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

//        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
//    }

//    public async Task MarkUserAsLoggedOut()
//    {
//        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
//        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
//    }
//}