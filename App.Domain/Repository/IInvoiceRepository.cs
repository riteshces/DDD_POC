using App.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Repository
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceMaster>> GetInvoicesAsync();
        Task<InvoiceMaster> GetInvoiceByIdAsync(string id);
        Task<InvoiceMaster> AddInvoiceAsync(InvoiceMaster invoice);
        Task<InvoiceMaster> UpdateInvoiceAsync(string id, InvoiceMaster invoice);

    }
}
