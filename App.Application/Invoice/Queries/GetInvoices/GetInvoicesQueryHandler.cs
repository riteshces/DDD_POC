using App.Domain.Repository;
using AutoMapper;
using MediatR;

namespace App.Application.Invoice.Queries.GetInvoices
{
    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, List<InvoiceViewModel>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoicesQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<List<InvoiceViewModel>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceRepository.GetInvoicesAsync();
            return _mapper.Map<List<InvoiceViewModel>>(invoices).ToList();
        }
    }
}
