using MediatR;

namespace App.Application.Invoice.Queries.GetInvoices
{
    public class GetInvoicesQuery : IRequest<List<InvoiceViewModel>>
    {
    }
}
