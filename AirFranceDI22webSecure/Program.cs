using AirFranceDI22Model.Context;
using AirFranceDI22Model.Dao;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connexionString = builder.Configuration.GetConnectionString("default");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AirFranceDI22Context>(
    options => options.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString)));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AirFranceDI22Context>().AddDefaultTokenProviders();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
