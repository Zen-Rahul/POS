using Microsoft.AspNetCore.Mvc;
using NLog;
using POS.Api;
using System.Text.Json.Serialization;

var logger = LogManager.Setup().LoadConfigurationFromXml("NLog.Config").GetCurrentClassLogger();
logger.Debug("Logger Intialized");

try
{
    var builder = WebApplication.CreateBuilder(args);
    const string MyAllowSpecificOrigins = "allowedOrigins";
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
    builder.Services.AddCors(); // Make sure you call this previous to AddMvc
    builder.ConfigureDataBase();
    builder.ConfigureLog();
    builder.ConfigureAutoMapper();
    builder.ConfigureSwagger();
    builder.ConfigureMediatR();
    builder.ConfigureFluentValidation();
    builder.AddScopedDependencies();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors(
        options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
    );
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopping application caught error in Program.cs");
    throw;
}
finally
{
    LogManager.Shutdown();
}