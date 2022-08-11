using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Data.Repositorio;
using CardapioDigital.Service.Interfaces;
using CardapioDigital.Service.Services;
using Microsoft.EntityFrameworkCore;

string politicaCors = "_politicaCors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CardapioDigitalContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddCors(option =>
    option.AddPolicy(
        name: politicaCors, 
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
    )
);

builder.Services.AddControllers()
                .AddNewtonsoftJson(option => 
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adicionando a injeção
// Service
builder.Services.AddScoped<IBebidaService, BebidaService>();
builder.Services.AddScoped<IBordaService, BordaService>();
builder.Services.AddScoped<ICategoriaBebidaService, CategoriaBebidaService>();
builder.Services.AddScoped<ICategoriaPizzaService, CategoriaPizzaService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<ITamanhoService, TamanhoService>();

builder.Services.AddScoped<ITipoService, TipoService>();

// Repositorio
builder.Services.AddScoped<IBebidaRepositorio, BebidaRepositorio>();
builder.Services.AddScoped<IGeralRepositorio, GeralRepositorio>();
builder.Services.AddScoped<IBordaRepositorio, BordaRepositorio>();
builder.Services.AddScoped<ICategoriaBebidaRepositorio, CategoriaBebidaRepositorio>();
builder.Services.AddScoped<ICategoriaPizzaRepositorio, CategoriaPizzaRepositorio>();
builder.Services.AddScoped<IPizzaRepositorio, PizzaRepositorio>();
builder.Services.AddScoped<ITamanhoRepositorio, TamanhoRepositorio>();
builder.Services.AddScoped<ITipoRepositorio, TipoRepositorio>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(politicaCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
