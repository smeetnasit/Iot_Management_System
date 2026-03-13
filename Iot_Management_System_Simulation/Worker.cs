namespace Iot_Management_System_Simulation
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly SimulationRepository _repository;
        private readonly Random _random = new Random();

        // ✅ Simulation state — can be paused/resumed
        public static bool IsRunning { get; set; } = true;

        public Worker(
            ILogger<Worker> logger,
            SimulationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            _logger.LogInformation("🚀 Simulation Worker started!");

            while (!stoppingToken.IsCancellationRequested)
            {
                if (IsRunning)
                {
                    await RunSimulation();
                }
                else
                {
                    _logger.LogInformation("⏸ Simulation paused...");
                }

                // ✅ Wait 30 seconds before next run
                await Task.Delay(30000, stoppingToken);
            }
        }

        private async Task RunSimulation()
        {
            _logger.LogInformation(
                $"⚡ Running simulation at: {DateTime.Now}");

            // Get all active sensors
            var sensors = await _repository.GetActiveSensors();

            if (!sensors.Any())
            {
                _logger.LogWarning("⚠️ No active sensors found!");
                return;
            }

            _logger.LogInformation(
                $"Found {sensors.Count} active sensors");

            foreach (var sensor in sensors)
            {
                // Generate random value between Min and Max
                double randomValue = GenerateRandomValue(
                    sensor.MinThreshold,
                    sensor.MaxThreshold
                );

                // Check if alert
                bool isAlert = randomValue < sensor.MinThreshold
                            || randomValue > sensor.MaxThreshold;

                var reading = new SensorReading
                {
                    Sensor_Id = sensor.Sensor_Id,
                    Reading_Value = Math.Round(randomValue, 2),
                    Is_Alert = isAlert
                };

                await _repository.InsertReading(reading);

                _logger.LogInformation(
                    $"✅ Sensor: {sensor.Sensor_Name} | " +
                    $"Value: {reading.Reading_Value} | " +
                    $"Alert: {isAlert}"
                );
            }
        }

        private double GenerateRandomValue(
            double min, double max)
        {
            // 80% chance normal, 20% chance alert
            bool generateAlert = _random.Next(100) < 20;

            if (generateAlert)
            {
                bool tooLow = _random.Next(2) == 0;
                if (tooLow)
                    return Math.Round(
                        min - _random.NextDouble() * (min * 0.2), 2);
                else
                    return Math.Round(
                        max + _random.NextDouble() * (max * 0.2), 2);
            }
            else
            {
                return Math.Round(
                    min + _random.NextDouble() * (max - min), 2);
            }
        }
    }
}