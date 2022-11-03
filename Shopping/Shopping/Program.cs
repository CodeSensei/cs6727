using DataDome;
using DataDome.Configuration;
using Google.Api;
using RestSharp;
using Shopping.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShoppingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingContext") ?? throw new InvalidOperationException("Connection string 'ShoppingContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
// Setup Datadome
builder.Services.Configure<DataDomeConfig>(builder.Configuration.GetSection("DataDomeConfiguration"));

// Setup Google
builder.Services.Configure<GoogleRecaptchaV3Model>(builder.Configuration.GetSection("GoogleRecaptchaV3Config"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Setup Datadome
app.UseDataDome();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
