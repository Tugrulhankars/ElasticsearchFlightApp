using FlightSearchApp;
using FlightSearchApp.Repositories;
using FlightSearchApp.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddElastic();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FlightRepository>();
builder.Services.AddScoped<FlightService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyMethod()  
              .AllowAnyHeader(); 
    });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); 

app.UseAuthorization();

app.MapControllers();

app.Run();

