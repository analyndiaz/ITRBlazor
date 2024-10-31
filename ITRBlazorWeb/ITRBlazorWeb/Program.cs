using Evolve.ITR.Infrastructure.Auth;
using Evolve.ITR.Infrastructure.DataAccess.Contexts;
using Evolve.ITR.ServiceContract.Abstractions;
using Evolve.ITR.ServiceContract.DTOs;
using ITRBlazorWeb.Auth;
using ITRBlazorWeb.Components;
using ITRBlazorWeb.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddSingleton<IDashboardService, DashboardService>();
builder.Services.AddSingleton<IVehicleOrderService, VehicleOrderService>();
builder.Services.AddSingleton<IPreRequisiteService, PreRequisiteService>();
builder.Services.AddSingleton<IDbResultCacheService, DbResultCacheService>();
builder.Services.AddMemoryCache();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("Main") ?? throw new InvalidOperationException("Connection string 'Main' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var titleQuestConnString = builder.Configuration.GetConnectionString("TitleQuest") ?? throw new InvalidOperationException("Connection string 'TitleQuest' not found.");
builder.Services.AddDbContextFactory<TitleQuestDbContext>(options => options.UseSqlServer(
    titleQuestConnString,
    sqlServerOptions => sqlServerOptions.CommandTimeout(60)));

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ITRBlazorWeb.Client._Imports).Assembly);

app.MapAdditionalIdentityEndpoints();
app.Run();
