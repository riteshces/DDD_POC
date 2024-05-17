using App.Application.Invoice.Queries.GetInvoices;
using App.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Invoice.Commands.CreateInvoice
{
    public class CreateInvoiceCommand:IRequest<InvoiceViewModel>
    {
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
