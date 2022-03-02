using DMStorefront.Shared;

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
