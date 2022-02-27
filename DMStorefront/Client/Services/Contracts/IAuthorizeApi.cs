using DMStorefront.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMStorefront.Client.Services.Contracts
{
    public interface IAuthorizeApi
    {
        Task Login(LoginParameters loginParameters);
        Task Register(RegisterParameters registerParameters);
        Task Update(UpdateAccountParameters updateParameters);
        Task Logout();
        Task<UserInfo> GetUserInfo();
    }
}
