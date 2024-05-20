using App.Application.Common.Mappings;
using App.Domain.Entity;

namespace App.Application.Invoice.Queries.GetInvoices
{
    public class InvoiceViewModel : IMapFrom<InvoiceMaster>
    {
        public string Id { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public CustomerMaster Customer { get; set; }
        public List<InvoiceDetails> Items { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal PayableAmount { get; set; }
    }
}
