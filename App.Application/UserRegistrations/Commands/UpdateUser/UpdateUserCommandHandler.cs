using App.Application.Customer.Queries.GetCustomers;
using App.Application.UserRegistrations.Queries;
using App.Domain.Entity;
using App.Domain.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UserRegistrations.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserRegistrationViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRegistartion _userRegistartion;

        public UpdateUserCommandHandler(IMapper mapper, IUserRegistartion userRegistartion)
        {
            _mapper = mapper;
            _userRegistartion = userRegistartion;
        }

        public async Task<UserRegistrationViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = new UserRegistration
            {
                Name = request.Name,
                ContactNo = request.ContactNo,
                UpdatedOn = DateTime.UtcNow,
                Status = "Active"
            };

            var user = await _userRegistartion.UpdateUserAsync(request.Id,userEntity);
            return _mapper.Map<UserRegistrationViewModel>(user);
        }
    }
}
