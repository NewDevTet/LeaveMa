using LeaveMa.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LeaveMaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                , optionsBuilder =>
                optionsBuilder.MigrationsAssembly("LeaveMa.Data")));
var app = builder.Build();

app.Run();
