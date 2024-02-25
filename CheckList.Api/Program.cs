using Checklist.Infra.Repositories;
using CheckList.Api.Extension;
using CheckList.Domain;
using CheckList.Domain.Interfaces.Repositories;
using CheckList.Domain.Interfaces.Services;
using CheckList.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

builder.Services.AddContext(configuration);

builder.Services.AddTransient<IPerguntaRepository, PerguntaRepository>();
builder.Services.AddTransient<ICheckListItemRepository, CheckListItemRepository>();
builder.Services.AddTransient<ICheckListRepository, CheckListRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddTransient<IPerguntaService, PerguntaService>();
builder.Services.AddTransient<ICheckListService, CheckListService>();

var app = builder.Build();

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
