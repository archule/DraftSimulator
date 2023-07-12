using Microsoft.AspNetCore.Builder;
using madden.Hubs;
using Microsoft.AspNetCore.Identity;
using madden.Models;
using madden.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using madden.Services;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.MemoryStorage;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddSignalR();

// add trasisent/scoped/singleton
// add trasisent/scoped/singleton



builder.Services.AddTransient<JsonFilePlayersService>();
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddTransient<IServiceManagement, ServiceManagement>(); 

// dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 3.1.0
// 
/*
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();
*/
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityContext>()
        .AddDefaultTokenProviders(); ;

//builder.Services.AddHangfireServer();

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseMemoryStorage());

builder.Services.AddDbContext<FireDbContext>(options =>
    options.UseInMemoryDatabase("YourDatabaseName"));


builder.Services.AddScoped<RoomRepo>();
builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// 
/*
builder.Services.AddDbContext<IdentityContext>(opts =>
    opts.UseSqlServer(builder.Configuration[
        "ConnectionStrings:IdentityConnection"]));
*/
builder.Services.AddDbContext<PlayerDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddDbContext<IdentityContext>(opt => opt.UseInMemoryDatabase("InMem"));
/* builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider(); */
builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.Name = "auth"; // Replace with your desired cookie name
            options.LoginPath = "/api/User/login"; // Replace with your login page path
        });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());


app.MapHub<ChatHub>("/chatHub");

app.UseRouting();

app.UseHangfireDashboard();
app.MapHangfireDashboard();

app.MapRazorPages();

app.UseAuthentication();
app.UseAuthorization();




app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/products", (context) =>
    {
        var products = app.Services.GetService<JsonFilePlayersService>().GetPlayers();
        var json = JsonSerializer.Serialize <IEnumerable<Player>>(products);
        return context.Response.WriteAsync(json);
    });
});

app.UseHttpsRedirection();




app.MapControllers();
app.UseStaticFiles();




app.Run();
