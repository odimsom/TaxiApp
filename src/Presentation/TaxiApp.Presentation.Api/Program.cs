using TaxiApp.Core.Application;
using TaxiApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureRepositories(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "TaxiApp API", 
        Version = "v1",
        Description = "API for TaxiApp"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaxiApp API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
