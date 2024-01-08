using AkarSoftware.ApiBestPractise.Core.Repositories;
using AkarSoftware.ApiBestPractise.Core.Services;
using AkarSoftware.ApiBestPractise.Core.UnitOfWorks;
using AkarSoftware.ApiBestPractise.Repository;
using AkarSoftware.ApiBestPractise.Repository.Repositories;
using AkarSoftware.ApiBestPractise.Repository.UnitOfWork;
using AkarSoftware.ApiBestPractise.Services.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer").ToString(), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


#region Services Register
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>))); // generic olarak tek tip alındığı için böyle eğer birden fazla generic alınsaydı <,,,> şeklinde parametre -1 kadar virgül atılacaktı
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
#endregion



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
