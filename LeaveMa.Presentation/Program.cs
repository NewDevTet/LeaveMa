using LeaveMa.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using LeaveMa.Data.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using LeaveMa.Presentation.EmailSender;
using LeaveMa.Business.DependencyInjection;
using LeaveMa.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LeaveMaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                , optionsBuilder =>
                optionsBuilder.MigrationsAssembly("LeaveMa.Data")));

builder.Services.AddApplication();

builder.Services.AddIdentity<Employee, IdentityRole>()
    .AddEntityFrameworkStores<LeaveMaDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.TryAddTransient<IEmailSender, EmailSender>();



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
