using DesafioPokemon.Infra.Context;
using DesafioPokemon.Infra.Uow;
using DesafioPokemon.Models;
using DesafioPokemon.Repositories;
using DesafioPokemon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
                            options.UseSqlite(
                            builder.Configuration.GetConnectionString("ConexaoSQL"))
                            );
builder.Services.AddScoped<IMasterPokemonRepository, MasterPokemonRepository>();
//builder.Services.AddTransient<IEvolutionRepository, EvolutionRepository>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IPokemonCapturedRepository, PokemonCapturedRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
