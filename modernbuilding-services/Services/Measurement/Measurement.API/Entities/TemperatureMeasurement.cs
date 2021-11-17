using System;

namespace Measurement.API.Entities
{
    public class TemperatureMeasurement
    {
        public string Id { get; set; }
        public string SensorName { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
