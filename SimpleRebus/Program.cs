using Rebus.Config;
using Rebus.Routing.TypeBased;
using SimpleRebus.Incoming;
using SimpleRebus.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRebusHandler<ProjectHandler>();
builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseAzureServiceBus(builder.Configuration["AzureServiceBusConnectionString"], "teamplannera"))
    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Debug))
    .Routing(r => 
        r.TypeBased()
            .Map<Project>("project")
            .Map<Resource>("resource")
            .Map<SimpleRebus.Models.Task>("task")), isDefaultBus: true
);

//builder.Services.AddRebus(configure => configure
//    .Transport(t => t.UseAzureServiceBus(builder.Configuration["AzureServiceBusConnectionString"], "teamplannerb"))
//    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Debug))
//    .Routing(r =>
//        r.TypeBased()
//            .Map<Project>("project")
//            .Map<Resource>("resource")
//            .Map<SimpleRebus.Models.Task>("task"))
//);

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
