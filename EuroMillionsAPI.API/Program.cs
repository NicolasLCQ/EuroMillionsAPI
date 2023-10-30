using EuroMillionsAPI.Helpers;
using EuroMillionsAPI.Repository;
using EuroMillionsAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<SharedService>();
builder.Services.AddScoped<DrawService>();

builder.Services.AddScoped<Downloader>();
builder.Services.AddScoped<CsvParser>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<EuromillionDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 34)),
            optionsBuilder => optionsBuilder.MigrationsAssembly("EuroMillionsAPI.API")
         )
        .LogTo(Console.WriteLine, LogLevel.Trace)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()

);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();