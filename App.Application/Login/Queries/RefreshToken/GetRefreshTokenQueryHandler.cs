using App.Domain.Entity;
using App.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Login.Queries.RefreshToken
{
    public class GetRefreshTokenQueryHandler : IRequestHandler<GetRefreshTokenQuery, LoginResponseViewModel>
    {
        protected readonly ILogin _login;

        public GetRefreshTokenQueryHandler(ILogin login)
        {
            _login = login;
        }

        public async Task<LoginResponseViewModel> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            LoginUserResponse loginUserResponse = await _login.GenerateRefreshToken(request.token, request.refreshtoken);
            if (loginUserResponse == null)
            {
                return new LoginResponseViewModel();
            }
            return new LoginResponseViewModel { IsLogin= loginUserResponse.isLogin, token=loginUserResponse.token, refreshtoken=loginUserResponse.refreshtoken };
        }
    }
}
