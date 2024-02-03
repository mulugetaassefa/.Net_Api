using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AdvisoryApp.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("AdvisorUserName")]
        public string AdvisorUserName { get; set; } = string.Empty;

        [BsonElement("StudentUserName")]
        public string StudentUserName { get; set; } = string.Empty;

        [BsonElement("date")]
        public string Date { get; set; } = string.Empty;


    }
}
