using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<SuperHeroDatabaseSettings>(builder.Configuration.GetSection(nameof(SuperHeroDatabaseSettings)));

builder.Services.AddSingleton<ISuperHeroDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SuperHeroDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("SuperHeroDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IHeroService, HeroService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("SuperHeroPolicy",
    policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
    }
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SuperHeroPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
