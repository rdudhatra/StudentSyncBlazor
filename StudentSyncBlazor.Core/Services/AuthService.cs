//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Http;
//using StudentSyncBlazor.Core.Services.Interface;
//using StudentSyncBlazor.Core.Wrapper;
//using StudentSyncBlazor.Data.Data;
//using StudentSyncBlazor.Data.Models;
//using StudentSyncBlazor.Data.ViewModels;
//using System.Security.Claims;

//namespace StudentSyncBlazor.Core.Services
//{
//    public class AuthService : IAuthService
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly StudentSyncDbContext _context;

//        private const string AdminEmail = "admin@example.com";
//        private const string AdminPassword = "Admin@123";


//        public AuthService(IHttpContextAccessor httpContextAccessor, StudentSyncDbContext context)
//        {
//            _httpContextAccessor = httpContextAccessor;
//            _context = context;
//        }

//        public async Task<IResult> RegisterAsync(RegisterViewModel model)
//        {
//            try
//            {
//                var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
//                if (existingUser != null)
//                {
//                    return Result.Fail("User with this email already exists.");
//                }

//                var user = new User
//                {
//                    Email = model.Email,
//                    Username = model.Username,
//                    Password = model.Password 
//                };

//                _context.Users.Add(user);
//                await SignInAsync(user);


//                await _context.SaveChangesAsync();


//                return Result.Success("Registration successful.");
//            }
//            catch (Exception ex)
//            {
//                return Result.Fail($"An error occurred during registration: {ex.Message}");
//            }
//        }

//        public async Task<IResult> LoginAsync(LoginViewModel model)
//        {
//            try
//            {
//                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

//                if (user != null && user.Password == model.Password)
//                {
//                    if(user.Username ==  model.Username) 
//                    {
//                        return Result.Success("Login successful.");
//                        //await SignInAsync(user);
//                    }
//                    else
//                    {
//                        return Result.Fail("Invalid UserName.");
//                    }

//                }
//                else
//                {
//                    return Result.Fail("Invalid email or password.");
//                }


//            }
//            catch (Exception ex)
//            {
//                return Result.Fail($"An error occurred during login: {ex.Message}");
//            }
//        }


//        public async Task<IResult> LogoutAsync()
//        {
//            try
//            {
//                await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

//                return Result.Success("Logout successful.");
//            }
//            catch (Exception ex)
//            {
//                return Result.Fail($"An error occurred during logout: {ex.Message}");
//            }
//        }

//        public async Task<IResult> AdminLoginAsync(LoginViewModel model)
//        {
//            try
//            {
//                if (model.Email == AdminEmail && model.Password == AdminPassword)
//                {
//                    var adminClaims = new List<Claim>
//                    {
//                        new Claim(ClaimTypes.Name, "Admin"),
//                        new Claim(ClaimTypes.Email, AdminEmail),
//                        new Claim(ClaimTypes.Role, "Admin")
//                    };

//                    var adminIdentity = new ClaimsIdentity(adminClaims, CookieAuthenticationDefaults.AuthenticationScheme);
//                    var adminPrincipal = new ClaimsPrincipal(adminIdentity);

//                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, adminPrincipal);

//                    return Result.Success("Admin login successful.");
//                }
//                return Result.Fail("Invalid admin credentials.");
//            }
//            catch (Exception ex)
//            {
//                return Result.Fail($"An error occurred during admin login: {ex.Message}");
//            }
//        }

//        private async Task SignInAsync(User user)
//        {
//            try
//            {
//                var claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.Name, user.Username),
//                    new Claim(ClaimTypes.Email, user.Email)
//                };

//                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//                var principal = new ClaimsPrincipal(identity);

//                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
//            }
//            catch (Exception ex)
//            {
//                throw new InvalidOperationException("An error occurred during sign-in.", ex);
//            }
//        }

//    }
//}

using Microsoft.AspNetCore.Http;
using StudentSyncBlazor.Core.Services.Interface;
using StudentSyncBlazor.Core.Wrapper;
using StudentSyncBlazor.Data.Data;
using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly StudentSyncDbContext _context;
        private readonly CustomAuthenticationStateProvider _authStateProvider;

        public AuthService(IHttpContextAccessor httpContextAccessor, StudentSyncDbContext context, CustomAuthenticationStateProvider authStateProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _authStateProvider = authStateProvider;
        }
        public async Task<string> GetTokenAsync()
        {
            // Here you should implement your logic to retrieve the token.
            // This can be from a stored value, an API call, etc.
            // For example, you might retrieve the token from HttpContext.

            var token = _httpContextAccessor.HttpContext.Request.Cookies["AuthToken"];

            if (string.IsNullOrEmpty(token))
            {
                // Optionally handle the case where the token is not found
                throw new InvalidOperationException("No auth token found.");
            }

            return await Task.FromResult(token);
        }
        public async Task<IResult> RegisterAsync(RegisterViewModel model)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    return Result.Fail("User with this email already exists.");
                }

                var user = new User
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password // You should hash this password
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                await _authStateProvider.MarkUserAsAuthenticated(user.Username, user.Email);

                return Result.Success("Registration successful.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"An error occurred during registration: {ex.Message}");
            }
        }

        public async Task<IResult> LoginAsync(LoginViewModel model)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

                if (user != null && user.Password == model.Password)
                {
                    //await _authStateProvider.MarkUserAsAuthenticated(user.Username, user.Email);
                    return Result.Success("Login successful.");
                }

                return Result.Fail("Invalid email or password.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"An error occurred during login: {ex.Message}");
            }
        }

        public async Task<IResult> LogoutAsync()
        {
            try
            {
                await _authStateProvider.MarkUserAsLoggedOut();
                return Result.Success("Logout successful.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"An error occurred during logout: {ex.Message}");
            }
        }

        public async Task<IResult> AdminLoginAsync(LoginViewModel model)
        {
            try
            {
                // Assuming you have predefined admin credentials
                const string AdminEmail = "admin@example.com";
                const string AdminPassword = "Admin@123";

                if (model.Email == AdminEmail && model.Password == AdminPassword)
                {
                  //  await _authStateProvider.MarkUserAsAuthenticated("Admin", AdminEmail);
                    return Result.Success("Admin login successful.");
                }

                return Result.Fail("Invalid admin credentials.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"An error occurred during admin login: {ex.Message}");
            }
        }
    }
}
