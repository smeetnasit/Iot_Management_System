using Iot_Management_System_API;
using Iot_Management_System_API.DTO;
using Iot_Management_System_API.Interface;
using Iot_Management_System_API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<DBContext>();
builder.Services.AddSingleton<CommonResponse>();
builder.Services.AddSingleton<ISensor, Sensor_Repository>();

// ✅ CORS must be registered BEFORE builder.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMVC", policy =>
    {
        policy.WithOrigins("https://localhost:7051")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ CORS must be used BEFORE UseHttpsRedirection
app.UseCors("AllowMVC");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();