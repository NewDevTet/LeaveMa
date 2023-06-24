using LeaveMa.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using LeaveMa.Data.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LeaveMaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                , optionsBuilder =>
                optionsBuilder.MigrationsAssembly("LeaveMa.Data")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<LeaveMaDbContext>()
     .AddDefaultUI()
    .AddDefaultTokenProviders();
   



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



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
    pattern: "{controller=Home}/{action=Index}");
//"{controller=User}/{action=Login}");


app.MapRazorPages();

app.Run();
