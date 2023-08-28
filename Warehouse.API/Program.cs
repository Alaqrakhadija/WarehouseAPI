using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Profiles;
using Warehouse.Application.Services;
using Warehouse.Domain.RepoInterfaces;
using Warehouse.Infrastructure.DbContexts;
using Warehouse.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ILocationRepository,LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IContainerRepository, ContainerRepository>();
builder.Services.AddScoped<IContainerService, ContainerService>();
builder.Services.AddDbContext<WarehouseContext>(dbContextOptions =>
dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseDBConnectionString")
));
builder.Services.AddAutoMapper(typeof(PackageProfile), typeof(ContainerProfile)
    , typeof(LocationProfile), typeof(UserProfile), typeof(SchedulingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
