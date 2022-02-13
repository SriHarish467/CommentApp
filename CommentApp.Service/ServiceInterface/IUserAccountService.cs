using CommentApp.Service.Dto;
using System.Threading.Tasks;



namespace CommentApp.Service.ServiceInterface
{
    public interface IUserAccountService
    {
        Task<string> CreateNewUserAccountAsync(NewUserAccountDto newUserAccountDto);
        Task<string> ValidateUserCredentialAsync(LoginDto loginCredentail);
        Task<string> ForgotPasswordAsync(RestUserAccountDto restUserAccountDto);
        Task<bool> CheckEmailIdExistAsync(string emailId);
    }
}
