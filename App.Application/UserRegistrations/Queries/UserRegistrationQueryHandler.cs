using App.Domain.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UserRegistrations.Queries
{
    public class UserRegistrationQueryHandler : IRequestHandler<UserRegistrationQuery, UserRegistrationViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRegistartion _userRegistartion;

        public UserRegistrationQueryHandler(IMapper mapper, IUserRegistartion userRegistartion)
        {
            _mapper = mapper;
            _userRegistartion = userRegistartion;
        }

        public async Task<UserRegistrationViewModel> Handle(UserRegistrationQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRegistartion.GetByIdAsync(request.Id);
            return _mapper.Map<UserRegistrationViewModel>(user);
        }
    }
}
