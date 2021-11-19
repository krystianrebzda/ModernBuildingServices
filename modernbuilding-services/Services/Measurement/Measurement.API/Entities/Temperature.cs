using System;

namespace Measurement.API.Entities
{
    public class Temperature
    {
        public string Id { get; set; }
        public string SensorName { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
