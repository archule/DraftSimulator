using Microsoft.AspNetCore.Builder;
using madden.Hubs;
using Microsoft.AspNetCore.Identity;
using madden.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using madden.Services;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

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

// dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 3.1.0
// 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthorization();

// 
builder.Services.AddDbContext<IdentityContext>(opts =>
    opts.UseSqlServer(builder.Configuration[
        "ConnectionStrings:IdentityConnection"]));

builder.Services.AddDbContext<PlayerDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
/* builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider(); */
builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();




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

app.MapRazorPages();

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

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();




app.Run();
