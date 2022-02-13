using CommentApp.Domain.Model;
using System;
using System.Threading.Tasks;



namespace CommentApp.Repository.RepositoryInterface
{
    public interface IUserAccountRepository
    {
        Task<Guid> CreateNewUserAccountAsync(UserAccount userAccount);
        Task<Guid?> ValidateUserCredentialAsync(UserAccount userCredentail);
        Task<string> ForgotPasswordAsync(UserAccount userCredentail);
    }
}
