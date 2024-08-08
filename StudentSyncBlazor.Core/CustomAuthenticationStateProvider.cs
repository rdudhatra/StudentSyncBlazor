using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using StudentSyncBlazor.Core.Services.Interface;
using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;



//public class CustomAuthenticationStateProvider : AuthenticationStateProvider
//{
//    private readonly IJSRuntime _jsRuntime;
//    private readonly IHttpClientFactory _httpClientFactory;

//    private const string TokenKey = "authToken";

//    public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IHttpClientFactory httpClientFactory)
//    {
//        _jsRuntime = jsRuntime;
//        _httpClientFactory = httpClientFactory;
//    }

//    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//    {
//        var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TokenKey);

//        if (string.IsNullOrEmpty(token))
//        {
//            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
//        }

//        var handler = new JwtSecurityTokenHandler();
//        var jwtToken = handler.ReadJwtToken(token);

//        var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
//        var user = new ClaimsPrincipal(identity);

//        return new AuthenticationState(user);
//    }

//    public async Task SetTokenAsync(string token)
//    {
//        if (string.IsNullOrEmpty(token))
//        {
//            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
//        }
//        else
//        {
//            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
//        }

//        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
//    }
//}


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

        // Check if there's a JWT token in the cookies
        var token = _httpContextAccessor.HttpContext?.Request.Cookies["authToken"];
        if (string.IsNullOrEmpty(token))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        // Validate and extract claims from the token
        var claims = ValidateToken(token);
        if (claims == null)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var claimsIdentity = new ClaimsIdentity(claims, "jwtAuth_type");
        return new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
    }

    //public async Task MarkUserAsAuthenticated(string token)
    //{
    //    // Store the token in cookies
    //    _httpContextAccessor.HttpContext?.Response.Cookies.Append("authToken", token, new CookieOptions
    //    {
    //        HttpOnly = true,
    //        Secure = true, // Ensure this is set based on your environment
    //        SameSite = SameSiteMode.Strict
    //    });

    //    var claims = ValidateToken(token);
    //    if (claims == null)
    //    {
    //        throw new Exception("Invalid token");
    //    }

    //    var claimsIdentity = new ClaimsIdentity(claims, "jwtAuth_type");
    //    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

    //    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    //}

    public async Task MarkUserAsAuthenticated(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var claims = new List<Claim>(jwtToken.Claims);
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true
        };

       // await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
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
    //public async Task MarkUserAsLoggedOut()
    //{
    //    _httpContextAccessor.HttpContext?.Response.Cookies.Delete("authToken");

    //    var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
    //    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
    //}

    public async Task MarkUserAsLoggedOut()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
    }

    private IEnumerable<Claim> ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var jwtToken = tokenHandler.ReadJwtToken(token);
            if (jwtToken == null  || jwtToken.ValidTo < DateTime.UtcNow)
            {
                return null;
            }

            return jwtToken.Claims;
        }
        catch
        {
            return null;
        }
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

//    public async Task MarkUserAsAuthenticated(string username, string email)
//    {
//        var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.Name, username),
//                new Claim(ClaimTypes.Email, email),
//            };

//        var claimsIdentity = new ClaimsIdentity(claims, "apiauth_type");
//        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

//        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
//    }

//    public async Task MarkUserAsLoggedOut()
//    {
//        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
//        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
//    }
//}
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