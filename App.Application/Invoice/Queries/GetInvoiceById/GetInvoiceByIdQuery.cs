using App.Application.Invoice.Queries.GetInvoices;
using MediatR;

namespace App.Application.Invoice.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceViewModel>
    {
        public string Id { get; set; }
    }
}
