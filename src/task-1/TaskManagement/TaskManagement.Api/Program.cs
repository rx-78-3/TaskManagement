using Common.Exceptions.Handler;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.DataAccess;
using TaskManagement.Api.Endpoint.GetTasks;
using TaskManagement.Api.Mapping;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration["ConnectionStrings:SqlServer"]!;
var frontendUrl = configuration["ServiceAddresses:FrontendUrl"]!;

// Add services to the container.
builder.Services
    .AddCors(options =>
    {
        options.AddPolicy(
                "AllowSpecificOrigin",
                policy => policy
                    .WithOrigins(frontendUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod());
    })
    
    // Swagger.
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()

    .AddExceptionHandler<ServiceWideExceptionHandler>()

    // Configure DbContext with SQL Server.
    .AddDbContext<TasksDbContext>(options =>
        options.UseSqlServer(connectionString)); 

var app = builder.Build();

MappingConfig.RegisterMappings();

// Simplification for Dev environment. 
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TasksDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseCors("AllowSpecificOrigin");
app.MapGetTasks();
app.UseExceptionHandler(options => { });

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasks API V1");
});

app.Run();
