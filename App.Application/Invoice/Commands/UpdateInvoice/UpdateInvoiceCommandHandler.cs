using App.Application.Invoice.Commands.CreateInvoice;
using App.Application.Invoice.Queries.GetInvoices;
using App.Domain.Entity;
using App.Domain.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Invoice.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, InvoiceViewModel>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceViewModel> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceEntity = new InvoiceMaster
            {
                InvoiceDate = request.InvoiceDate,
                InvoiceNo = request.InvoiceNo,
                Customer = request.Customer,
                DiscountAmount = request.DiscountAmount,
                GSTAmount = request.GSTAmount,
                Items = request.Items,
                PayableAmount = request.PayableAmount,
                SubTotalAmount = request.SubTotalAmount,
                TaxableAmount = request.TaxableAmount
            };
            var invoice = await _invoiceRepository.UpdateInvoiceAsync(request.Id,invoiceEntity);
            return _mapper.Map<InvoiceViewModel>(invoice);
        }
    }
}
