using App.Application.Invoice.Queries.GetInvoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Invoice.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery:IRequest<InvoiceViewModel>
    {
        public string Id { get; set; }
    }
}
