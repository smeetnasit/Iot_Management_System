namespace Iot_Management_System_Simulation
{
    public class ActiveSensor
    {
        public int Sensor_Id { get; set; }
        public string? Sensor_Name { get; set; }
        public double MinThreshold { get; set; }
        public double MaxThreshold { get; set; }
    }

    public class SensorReading
    {
        public int Sensor_Id { get; set; }
        public double Reading_Value { get; set; }
        public bool Is_Alert { get; set; }
    }
}