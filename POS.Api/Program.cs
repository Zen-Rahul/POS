using NLog;
using POS.Api;

var logger = LogManager.Setup().LoadConfigurationFromXml("NLog.Config").GetCurrentClassLogger();
logger.Debug("Logger Intialized");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.ConfigureDataBase();
    builder.ConfigureLog();
    builder.ConfigureAutoMapper();
    builder.ConfigureSwagger();
    builder.ConfigureMediatR();
    builder.ConfigureFluentValidation();
    builder.AddSingletonDependencies();
    builder.AddScopedDependencies();
    builder.AddTransitiveDependencies();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

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