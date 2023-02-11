using Assignment.Repositories;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using POS.Api.CHQV.Commands;
using POS.Api.CHQV.Queries;
using POS.Api.CHQV.Validators;
using POS.Api.Data;
using POS.Api.DTOs;
using POS.Api.Filters;
using POS.Api.Repositories;
using POS.Api.Repositories.Base;
using POS.Api.Repositories.Interfaces;

namespace POS.Api
{
    public static class POSAppBuilder
    {
        public static void ConfigureDataBase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<POSContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("POSConnStr")));
        }

        public static void ConfigureLog(this WebApplicationBuilder builder)
        {
            // NLog: Setup NLog for Dependency injection
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Host.UseNLog();
        }

        public static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            // Learn more about configuring Swagger/ OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<EnumSchemaFilter>();
            });
        }

        public static void ConfigureAutoMapper(this WebApplicationBuilder builder)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            var mapper = config.CreateMapper();

            builder.Services.AddSingleton(mapper);
        }

        public static void ConfigureMediatR(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(GetItems));
            builder.Services.AddMediatR(typeof(CreateInventoryCommand));
            builder.Services.AddMediatR(typeof(PlaceOrderCommand));
        }

        public static void ConfigureFluentValidation(this WebApplicationBuilder builder)
        {
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddScoped<IValidator<GetItems>, GetItemsValidator>();
            builder.Services.AddScoped<IValidator<CreateInventoryCommand>, CreateInventoryValidator>();
        }

        public static void AddSingletonDependencies(this WebApplicationBuilder builder)
        {
        }

        public static void AddScopedDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
        }

        public static void AddTransitiveDependencies(this WebApplicationBuilder builder)
        {
        }

    }
}
