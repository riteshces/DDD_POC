using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entity
{
    public class CustomerMaster
{
        [BsonId]
        [BsonElement("_id"),BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("customername"), BsonRepresentation(BsonType.String)]
        public string CustomerName { get; set; }

        [BsonElement("address"), BsonRepresentation(BsonType.String)]
        public string Address { get; set; }

        [BsonElement("city"), BsonRepresentation(BsonType.String)]
        public string City { get; set; }

        [BsonElement("pincode"), BsonRepresentation(BsonType.String)]
        public string Pincode { get; set; }

        [BsonElement("country"), BsonRepresentation(BsonType.String)]
        public string Country { get; set; }

        [BsonElement("contactno"), BsonRepresentation(BsonType.String)]
        public string ContactNo { get; set; }

        [BsonElement("emailid"), BsonRepresentation(BsonType.String)]
        public string EmailId { get; set; }

    }
}
