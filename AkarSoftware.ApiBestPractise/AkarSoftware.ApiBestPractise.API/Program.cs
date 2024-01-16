using AkarSoftware.ApiBestPractise.API.Filters;
using AkarSoftware.ApiBestPractise.API.Helpers;
using AkarSoftware.ApiBestPractise.API.Middlewares;
using AkarSoftware.ApiBestPractise.API.Modules;
using AkarSoftware.ApiBestPractise.Core.Repositories;
using AkarSoftware.ApiBestPractise.Core.Services;
using AkarSoftware.ApiBestPractise.Core.UnitOfWorks;
using AkarSoftware.ApiBestPractise.Repository;
using AkarSoftware.ApiBestPractise.Repository.Repositories;
using AkarSoftware.ApiBestPractise.Repository.UnitOfWork;
using AkarSoftware.ApiBestPractise.Services.MappingProfiles;
using AkarSoftware.ApiBestPractise.Services.Services;
using AkarSoftware.ApiBestPractise.Services.Validations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Framework ün belirlemiş olduğu model bu şekilde baskılandı. 

builder.Services.AddControllers(x =>
{
    x.Filters.Add(new ValidateFilterAttribute());
})

    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>())
    .AddMvcOptions(opt =>
{
    opt.Conventions.Add(new LowercaseControllerModelConvention());
});
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer").ToString(), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(x => x.RegisterModule(new RepoServiceModule()));
#region Services Register


#endregion



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCostumeException();

app.UseAuthorization();

app.MapControllers();

app.Run();
