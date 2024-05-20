using App.Application.Customer.Queries.GetCustomers;
using App.Domain.Entity;
using App.Domain.Repository;
using AutoMapper;
using MediatR;

namespace App.Application.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerViewModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = new CustomerMaster
            {
                Address = request.Address,
                City = request.City,
                ContactNo = request.ContactNo,
                Country = request.Country,
                EmailId = request.EmailId,
                CustomerName = request.CustomerName,
                Pincode = request.Pincode
            };
            var customer = await _customerRepository.UpdateCustomerAsync(request.Id, customerEntity);
            return _mapper.Map<CustomerViewModel>(customer);
        }
    }
}
