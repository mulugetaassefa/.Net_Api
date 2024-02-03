using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace AdvisoryApp.Models
{
    public class Advisor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; } = string.Empty;
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("speciality")]
        public string Speciality { get; set; } = string.Empty;

        [BsonElement("email")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [BsonElement("gender")]
        public string Gender { get; set; } = string.Empty;

        [BsonElement("phone")]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("photoUrl")]
        public string? PhotoUrl { get; set; }


    }
}
