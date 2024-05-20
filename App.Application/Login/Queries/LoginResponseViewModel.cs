using App.Application.Common.Mappings;
using App.Domain.Entity;
using MediatR.NotificationPublishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Login.Queries
{
    public class LoginResponseViewModel : IMapFrom<LoginUserResponse>
    {
        public bool IsLogin { get; set; }
        public string token { get; set; }
        public string refreshtoken { get; set; }
    }
}
