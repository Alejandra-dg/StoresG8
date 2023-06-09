using Microsoft.EntityFrameworkCore;
using Stores.API.Services;
using StoresG8.API.Data;
using StoresG8.API.Services.Stores.API.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Inyecci�n de dependencias del servicio SQl Server
builder.Services.AddDbContext<DataContext > (x => x.UseSqlServer("name=DefaultConnection"));
// Inyecci�n de el SeedDb
builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped<IApiService, ApiService>();




var app = builder.Build();

// esta funci�n ayuda a que las funciones del SeedData Se realicen
SeedData(app);

void SeedData(WebApplication app)
{
    Console.WriteLine("Seeding data");
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory!.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();



app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());


app.MapControllers();

app.Run();
