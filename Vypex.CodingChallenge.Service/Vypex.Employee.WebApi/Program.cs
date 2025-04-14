using Microsoft.EntityFrameworkCore;
using Vypex.Employee.Repositories.DataAccess;
using Vypex.Employee.WebApi.Core;
using Vypex.Employee.WebApi.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;

builder.Services.AddDbContext<VypexEmployeeDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetSection("connectionString")?.Value?.ToString()));
builder.Services.AddControllers();
builder.Services
    .AddServices()
    .AddRepository();

builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
}
app.UseMiddleware<VypexLoggingMiddleware>();
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
