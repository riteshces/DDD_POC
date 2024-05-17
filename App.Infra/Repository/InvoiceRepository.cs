using App.Domain.Entity;
using App.Domain.Repository;
using App.Infra.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDBContext _appDBContext;

        public InvoiceRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<InvoiceMaster> AddInvoiceAsync(InvoiceMaster invoice)
        {
            await _appDBContext.Invoices.InsertOneAsync(invoice);
            return invoice;
        }

        public async Task<InvoiceMaster> GetInvoiceByIdAsync(string id)
        {
            var filter = Builders<InvoiceMaster>.Filter.Eq(c => c.Id, id);
            var invoice = await _appDBContext.Invoices.FindAsync(filter).Result.FirstOrDefaultAsync();
            return invoice;
        }

        public async Task<List<InvoiceMaster>> GetInvoicesAsync()
        {
            var invoices = await _appDBContext.Invoices.Find(FilterDefinition<InvoiceMaster>.Empty).ToListAsync();
            return invoices;
        }

        public async Task<InvoiceMaster> UpdateInvoiceAsync(string id, InvoiceMaster invoice)
        {
            var filter = Builders<InvoiceMaster>.Filter.Eq(c => c.Id, id);
            var update = Builders<InvoiceMaster>.Update
                .Set(c => c.InvoiceDate, invoice.InvoiceDate)
                .Set(c => c.Customer, invoice.Customer)
                .Set(c => c.DiscountAmount, invoice.DiscountAmount)
                .Set(c => c.GSTAmount, invoice.GSTAmount)
                .Set(c => c.InvoiceNo, invoice.InvoiceNo)
                .Set(c => c.Items, invoice.Items)
                .Set(c => c.PayableAmount, invoice.PayableAmount)
                .Set(c => c.SubTotalAmount, invoice.SubTotalAmount)
                .Set(c => c.TaxableAmount, invoice.TaxableAmount);
            var result = _appDBContext.Invoices.UpdateOneAsync(filter, update);
            return await _appDBContext.Invoices.FindAsync(filter).Result.FirstOrDefaultAsync();
        }
    }
}
