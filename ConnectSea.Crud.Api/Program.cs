using ConnectSea.Crud.Api.Middlewares;
using ConnectSea.Crud.Infra.Context;
using ConnectSea.Crud.Infra.DependencyInjection;
using ConnectSea.Crud.Infra.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("NpgConnection");

builder.Services.AddDbContext<DbCtx>(options => options.UseNpgsql(connectionString));

builder.Services.RegisterServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DbCtx>();
    await SeedData.InitializeAsync(context, app.Environment.ContentRootPath);
}

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();