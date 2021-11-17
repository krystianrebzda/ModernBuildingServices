using System.Collections.Generic;

namespace Measurement.API.Entities
{
    public class MeasurementData
    {
        public IEnumerable<TemperatureMeasurement> Temperatures { get; set; }
    }
}
