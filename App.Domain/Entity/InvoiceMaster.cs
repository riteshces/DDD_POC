using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Domain.Entity
{
    public class InvoiceMaster
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("invoiceno"), BsonRepresentation(BsonType.String)]
        public string InvoiceNo { get; set; }

        [BsonElement("invoicedate"), BsonRepresentation(BsonType.String)]
        public string InvoiceDate { get; set; }

        [BsonElement("customer")]
        public CustomerMaster Customer { get; set; }

        [BsonElement("items")]
        public List<InvoiceDetails> Items { get; set; }

        [BsonElement("subtotalamount"), BsonRepresentation(BsonType.Decimal128)]
        public decimal SubTotalAmount { get; set; }

        [BsonElement("discountamount"), BsonRepresentation(BsonType.Decimal128)]
        public decimal DiscountAmount { get; set; }

        [BsonElement("taxableamount"), BsonRepresentation(BsonType.Decimal128)]
        public decimal TaxableAmount { get; set; }

        [BsonElement("gstamount"), BsonRepresentation(BsonType.Decimal128)]
        public decimal GSTAmount { get; set; }

        [BsonElement("payableamount"), BsonRepresentation(BsonType.Decimal128)]
        public decimal PayableAmount { get; set; }
    }
}
