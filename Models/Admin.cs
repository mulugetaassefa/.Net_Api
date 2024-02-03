using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System.ComponentModel.DataAnnotations;

namespace AdvisoryApp.Models
{
    [BsonIgnoreExtraElements]
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; } = string.Empty;

        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("dateOfBirth")]
        public string DateOfBirth { get; set; } = string.Empty;

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

        [BsonElement("password")]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
