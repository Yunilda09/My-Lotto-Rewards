using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_AP1.Areas.Identity;
using ProyectoFinal_AP1.DAL;
using ProyectoFinal_AP1.BLL;
using Radzen;
using Radzen.Blazor.Rendering;
//using RadzenBlazorDemos.Data;
//using RadzenBlazorDemos.Models.Northwind;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlite(connectionString)
    );

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Contexto>();

/*builder.Services.AddDefaultIdentity<IdentityUser>(options =>
                                 options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Contexto>();*/

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

builder.Services.AddScoped<GananciasBLL>();
builder.Services.AddScoped<LoteriasBLL>();
builder.Services.AddScoped<TipoJugadasBLL>();
builder.Services.AddScoped<TicketsBLL>();
builder.Services.AddScoped<UsuariosBLL>();

//Radzen
builder.Services.AddScoped<DialogService>();
services.AddScoped<NotificationService>();
services.AddScoped<TooltipService>();
services.AddScoped<ContextMenuService>();

//Authentication
builder.Services.AddAuthentication()
    .AddGoogle("google", options =>
    {
        var googleAuth = builder.Configuration.GetSection("Authentication:Google");
        options.ClientId = googleAuth["ClientId"];
        options.ClientSecret = googleAuth["ClientSecret"];
        options.SignInScheme = IdentityConstants.ExternalScheme;
    });

builder.Services.AddAuthentication().AddFacebook(facebookOptions =>

    { 
        facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];

        facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
