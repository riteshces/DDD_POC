using App.Domain.Entity;
using App.Domain.Repository;
using MediatR;

namespace App.Application.Login.Queries
{
    public class GetLoginQueryHandler : IRequestHandler<GetLoginQuery, LoginResponseViewModel>
    {
        protected readonly ILogin _login;

        public GetLoginQueryHandler(ILogin login)
        {
            _login = login;
        }

        public async Task<LoginResponseViewModel> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            LoginUser loginUser = new LoginUser { EmailId = request.EmailId, Password = request.Password };
            LoginUserResponse loginUserResponse = await _login.LoginAsync(loginUser);
            return new LoginResponseViewModel { IsLogin = loginUserResponse.isLogin, token = loginUserResponse.token, refreshtoken = loginUserResponse.refreshtoken };
        }
    }
}
