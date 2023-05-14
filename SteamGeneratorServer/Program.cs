using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using SteamGeneratorServer.Controllers;
using SteamGeneratorServer.Database;
using SteamGeneratorServer.Repositories.Measure;
using SteamGeneratorServer.Repositories.State;

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
app.UseSwaggerUI(c =>
{
	c.RoutePrefix = string.Empty;
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Steam Generator API API v1");
});

app.MapControllers();
app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
	ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();

app.Run();