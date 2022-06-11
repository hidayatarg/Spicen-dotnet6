using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spicen.API.Filters;
using Spicen.API.Middlewares;
using Spicen.API.Modules;
using Spicen.Core.Repositories;
using Spicen.Core.Services;
using Spicen.Core.UnitOfWorks;
using Spicen.Repository;
using Spicen.Repository.Repositories;
using Spicen.Repository.UnitOfWorks;
using Spicen.Service.Mapping;
using Spicen.Service.Services;
using Spicen.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// apply fluent validations to global
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribut())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
// turnoff the fluent behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Memory Cache
builder.Services.AddMemoryCache();

// DI Scopes

builder.Services.AddScoped(typeof(NotFoundFilter<>));
// autoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// sqlserver connections
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), sqlOptions =>
    {
        // sqlOptions.MigrationsAssembly("Spicen.Repository");
        sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// Ioc Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Global Exception Hanlder
app.UserCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
