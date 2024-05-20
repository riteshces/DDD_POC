using App.Domain.Repository;
using AutoMapper;
using MediatR;

namespace App.Application.Customer.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerViewModel>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<List<CustomerViewModel>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersAsync();
            var customerlist = _mapper.Map<List<CustomerViewModel>>(customers).ToList();
            return customerlist;
        }
    }
}
