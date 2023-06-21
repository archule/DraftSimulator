using Microsoft.AspNetCore.Builder;
using madden.Hubs;
using Microsoft.AspNetCore.Identity;
using madden.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddSignalR();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthorization();

/* builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider(); */
builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();

builder.Services.AddDbContext<IdentityContext>(opts =>
    opts.UseSqlServer(builder.Configuration[
        "ConnectionStrings:IdentityConnection"]));


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.Run();
