using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Temperature.Grpc.Entities
{
    public class SensorTemperature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string SensorName { get; set; }

        public decimal Value { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
