using System.Text.Json.Serialization;
using GSDrones.Data;
using GSDrones.Repositories;
using GSDrones.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddScoped<DroneService>();
builder.Services.AddScoped<DroneRepository>();
builder.Services.AddScoped<SuprimentoService>();
builder.Services.AddScoped<SuprimentoRepository>();
builder.Services.AddScoped<MissaoService>();
builder.Services.AddScoped<MissaoRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GS Drones REST API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();