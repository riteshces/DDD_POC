using App.Application.UserRegistrations.Queries;
using App.Domain.Entity;
using App.Domain.Repository;
using AutoMapper;
using MediatR;


namespace App.Application.UserRegistrations.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserRegistrationViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRegistartion _userRegistartion;

        public CreateUserCommandHandler(IUserRegistartion userRegistartion, IMapper mapper)
        {
            _userRegistartion = userRegistartion;
            _mapper = mapper;
        }

        public async Task<UserRegistrationViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = new UserRegistration
            {
                Name = request.Name,
                ContactNo = request.ContactNo,
                UserName = request.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedOn = DateTime.UtcNow,
                EmailId = request.EmailId,
                Status = "Active"
            };

            var user = await _userRegistartion.AddUserAsync(userEntity);
            return _mapper.Map<UserRegistrationViewModel>(user);
        }
    }
}
