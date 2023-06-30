using Rebus.Config;
using Rebus.Topic;
using SimpleRebus.Controllers;
using SimpleRebus.Incoming;
using SimpleRebus.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMyTransientService, MyService>();
builder.Services.AddScoped<IMyScopedService, MyService>();
builder.Services.AddSingleton<IMySingletonService, MyService>();


builder.Services.AddRebusHandler<ProjectHandler>();
builder.Services.AddRebusHandler<MyEventHandler>();
builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseAzureServiceBus(builder.Configuration["AzureServiceBusConnectionString"], "teamplanner-ndw"))
    .Logging(l => l.ColoredConsole(Rebus.Logging.LogLevel.Debug))
    //.Options(options => options.Register<ITopicNameConvention>(c => new MyCustomTopicNameConvention()))
);
//builder.Services.AddSingleton<ITopicNameConvention, TopicNameConvention>();

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
