using App.Application.Customer.Queries.GetCustomers;
using App.Domain.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerViewModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
            return _mapper.Map<CustomerViewModel>(customer);
        }
    }
}
