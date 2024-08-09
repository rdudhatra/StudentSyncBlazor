using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using StudentSync.Core.Services;
using StudentSyncBlazor.Core.Services;
using StudentSyncBlazor.Core.Services.Interface;
using StudentSyncBlazor.Core.Services.Interfaces;
using StudentSyncBlazor.Data;
using StudentSyncBlazor.Data.Data;
using StudentSyncBlazor.Pages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/login";
            options.LogoutPath = "/logout";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie expiration

        });

builder.Services.AddAuthorization();
builder.Services.AddDbContext<StudentSyncDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("StudentSyncBlazorCon")));

builder.Services.AddHttpClient();

var baseUrl = builder.Configuration.GetValue<string>("BaseUrl");
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(baseUrl),
    Timeout = Timeout.InfiniteTimeSpan

});


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
