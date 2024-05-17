using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Invoice.Queries.GetInvoices
{
    public class GetInvoicesQuery:IRequest<List<InvoiceViewModel>>
    {
    }
}
