using Iot_Management_System_Simulation;

var builder = Host.CreateApplicationBuilder(args);

// ✅ Register DBContext
builder.Services.AddSingleton<DBContext>();

// ✅ Register Repository
builder.Services.AddSingleton<SimulationRepository>();

// ✅ Register Worker
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();