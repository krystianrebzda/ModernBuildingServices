using System.Collections.Generic;

namespace Measurement.API.Entities
{
    public class MeasurementData
    {
        public IEnumerable<Temperature> Temperatures { get; set; }
    }
}
