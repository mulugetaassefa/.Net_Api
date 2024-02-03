using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AdvisoryApp.Models
{
    public class Chat
    {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? Id { get; set; }
            [BsonElement("AdisorUserName")]
            public string AdvisorUserName { get; set; } = string.Empty;

            [BsonElement("AdvisorUserName")]
            public string StudentUserName { get; set; } = string.Empty;

            [BsonElement("createdAt")]
            public string CreatedAt { get; set; } = string.Empty;

            [BsonElement("message")]
            public string Message { get; set; } = string.Empty;
        }
}
