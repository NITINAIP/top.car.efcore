using System.Text.Json.Serialization;
using Serilog;
using top.car.service.API.Middlewares;
using top.car.service.Application;
using top.car.service.Domain.Configurations;
using top.car.service.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
      options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
  });

// Serilog configuration
builder.Host.UseSerilog((ctx, lc) =>
{
    var serilogConfig = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("serilog.json", optional: false, reloadOnChange: true)
        .Build();

    lc.ReadFrom.Configuration(serilogConfig);
});
// Configure strongly typed settings objects
builder.Services.Configure<AzureAd>(builder.Configuration.GetSection("AzureAd"));
builder.Services.Configure<MailSender>(builder.Configuration.GetSection("MailSender"));
builder.Services.Configure<Storage>(builder.Configuration.GetSection("Storage"));



builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();


await app.RunAsync();

public partial class Program { }