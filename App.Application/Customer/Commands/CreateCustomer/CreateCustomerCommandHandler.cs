using App.Application.Customer.Queries.GetCustomers;
using App.Domain.Entity;
using App.Domain.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerViewModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = new CustomerMaster { Address=request.Address, City=request.City, ContactNo=request.ContactNo,
             Country=request.Country, EmailId=request.EmailId,
                CustomerName = request.CustomerName, Pincode= request.Pincode};
            var customer= await _customerRepository.AddCustomerAsync(customerEntity);
            return _mapper.Map<CustomerViewModel>(customer);
        }
    }
}
