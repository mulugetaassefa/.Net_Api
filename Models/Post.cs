using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AdvisoryApp.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("AdvisorUserName")]
        public string AdvisorUserName { get; set; } = string.Empty;

        [BsonElement("postPhoto")]
        public string? PhotoUrl { get; set; }

        [BsonElement("datePublished")]
        public string DatePublished { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;


    }
}
