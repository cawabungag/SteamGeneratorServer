using DailySpendingBot.Repositories;
using FinanceService.Controllers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var contentRootPath = builder.Environment.ContentRootPath;
services.AddSingleton<StateController>();
services.AddSingleton(new DatabaseHandler(contentRootPath));
services.AddSingleton<IStateRepository, StateRepository>();
services.AddSingleton<IMeasureRepository, MeasureRepository>();
services.AddControllers();

services.AddSwaggerGen(c
	=> c.SwaggerDoc("v1", new OpenApiInfo {Title = "Steam Generator Server", Version = "v1"}));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

app.Run();