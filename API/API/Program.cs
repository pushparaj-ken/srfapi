using API.Infrastructure;
using API.Middleware;
using Application;
using Application.Common;
using HR.LeaveManagement.Identity;
using Infrastructure;
using Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddScoped<APIResponseService>();

builder.Services.AddCors(options =>
options.AddPolicy("all", builder => builder.AllowAnyOrigin()
.AllowAnyHeader().AllowAnyMethod()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API 1.0");
});
app.UseMiddleware<ExceptionMiddleware>();//use latest //03-09-2024

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSerilogRequestLogging();

//app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

app.MapEndpoints();

app.Run();
