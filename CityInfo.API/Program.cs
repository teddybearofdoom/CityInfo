using CityInfo.API.Services;
using Microsoft.AspNetCore.StaticFiles;
using Serilog;

//third party serilog logger configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

////clear all default logging configuration
//builder.Logging.ClearProviders();
////we can add back what log config we want
//builder.Logging.AddConsole();

//tell builder to use serilog logger
builder.Host.UseSerilog();

//When you need a certain piece of functionality, you can write it in a 
//reusable service. Via dependency injection, that service can be injected
//into other services or classes when needed

//Inversion of Control and Dependency Injection
//Think of some controller who is dependent on lets say logging service plus some other service
//if we do not inject we'd have to write that service for each method inside the controller
//meaning class implementation has to change when a dependency changes and it makes it more difficult to test
//since the logger we're getting is a concrete type and we won't be able to pass mock types in our test
//lastly the class also need to manage the life time of the service as well - in short this makes the class tightly coupled

//this is where Inversion of Control comes to the rescue
//IoC delegates the function of selecting a concrete implementation type for a class's dependencies to an external component
//We accomplish that by Dependency Injection - it is a specialization of the Inversion of Control pattern which uses an object - 
//the container - to intializae objects and provide the required dependencies to the object

//All apis require certain some logging and we'll be injecting logger

// Add services to the container.

//returnhttpnotacceptable when accept header doesn't match request requested 
builder.Services.AddControllers(options => 
options.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

//to inject custom service we need to configure them
//we can also specify the lifetime of our service
//Transient - it would be created each time they are requested (best for lightweight stateless services)
//Scoped - created once per request
//Singleton - created first time they requested every subsequent request uses this instance

builder.Services.AddTransient<LocalMailService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.MapControllers();

app.Run();
