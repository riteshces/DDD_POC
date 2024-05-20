using App.Application.Invoice.Queries.GetInvoices;
using App.Domain.Entity;
using App.Domain.Repository;
using AutoMapper;
using MediatR;

namespace App.Application.Invoice.Commands.CreateInvoice
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, InvoiceViewModel>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceViewModel> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
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
            var invoice = await _invoiceRepository.AddInvoiceAsync(invoiceEntity);
            return _mapper.Map<InvoiceViewModel>(invoice);
        }
    }
}
