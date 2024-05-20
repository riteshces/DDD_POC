using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entity
{
    public class UserRegistration
    {
        [BsonId]
        [BsonElement("_id"),BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username"), BsonRepresentation(BsonType.String)]
        public string UserName { get; set; }

        [BsonElement("password"),BsonRepresentation(BsonType.String)]
        public string Password { get; set; }

        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement("contactno"), BsonRepresentation(BsonType.String)]
        public string ContactNo { get; set; }

        [BsonElement("emailid"), BsonRepresentation(BsonType.String)]
        public string EmailId { get; set; }

        [BsonElement("status"), BsonRepresentation(BsonType.String)]
        public string Status { get; set; }

        [BsonElement("createdon"), BsonRepresentation(BsonType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [BsonElement("updatedon"), BsonRepresentation(BsonType.DateTime)]
        public DateTime? UpdatedOn { get; set; }

        [BsonElement("refreshtoken"), BsonRepresentation(BsonType.String)]
        public string RefreshToken { get; set; }

        [BsonElement("refreshtokenexpiredon"), BsonRepresentation(BsonType.DateTime)]
        public DateTime? RefreshTokenExpiredOn { get; set; }
    }
}
