using MostafaProject.infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MostafaProject.Web.Resolver;

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
var app = builder.Build();

// Get All services class Dependency Injection from RegisterService Method 
builder.Services.AddApplicationServices();

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
