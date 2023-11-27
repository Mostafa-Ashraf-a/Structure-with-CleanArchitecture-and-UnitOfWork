using MostafaProject.infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MostafaProject.Web.Resolver;

using MostafaProject.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("DBConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingProfileBase));
// Get All services class Dependency Injection from RegisterService Method 
builder.Services.RegisterUnitOfWork<AppDbContext>();

builder.Services.AddApplicationServices();

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
