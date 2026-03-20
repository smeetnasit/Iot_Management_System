using Iot_Management_System_API;
using Iot_Management_System_API.DTO;
using Iot_Management_System_API.Interface;
using Iot_Management_System_API.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMVC", policy =>
    {
        policy.WithOrigins("https://localhost:7051", "https://app-iot-mvc-dev-aubdbfhyddgqghbt.westus2-01.azurewebsites.net")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddSingleton<DBContext>();
builder.Services.AddSingleton<CommonResponse>();
builder.Services.AddSingleton<ISensor, Sensor_Repository>();
builder.Services.AddSingleton<IUserRepository, User_Repository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowMVC");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();