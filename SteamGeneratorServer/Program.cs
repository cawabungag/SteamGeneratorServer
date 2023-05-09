using DailySpendingBot.Repositories;
using FinanceService.Controllers;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var contentRootPath = builder.Environment.ContentRootPath;
services.AddSingleton<StateController>();
services.AddSingleton(new DatabaseHandler(contentRootPath));
services.AddSingleton<IStateRepository, StateRepository>();
services.AddSingleton<IMeasureRepository, MeasureRepository>();
var app = builder.Build();
app.Run();