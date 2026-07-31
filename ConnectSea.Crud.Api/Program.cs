using ConnectSea.Crud.Api.Middlewares;
using ConnectSea.Crud.Infra.Context;
using ConnectSea.Crud.Infra.DependencyInjection;
using ConnectSea.Crud.Infra.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("NpgConnection");

builder.Services.AddDbContext<DbCtx>(options =>
    options.UseNpgsql(connectionString));

builder.Services.RegisterServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ConnectSea API",
        Version = "v1",
        Description = "API para gerenciamento de Manifestos e Escalas"
    });
});

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
app.UseCors("Angular");
app.UseAuthorization();
app.MapControllers();

app.Run();