using CommentApp.Domain.Context;
using CommentApp.Domain.Model;
using CommentApp.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CommentApp.Repository.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        #region Members
        private readonly CommentAppContext context;
        #endregion

        #region Constructor
        public UserAccountRepository(CommentAppContext _context)
        {
            context = _context;
        }
        #endregion

        #region Repository Methods
        /// <summary>
        /// CreateNewUserAccountAsync Method to create New User Account in the DB using Context Instance
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns>userId</returns>
        public async Task<Guid> CreateNewUserAccountAsync(UserAccount userAccount)
        {
            userAccount.IsActive = true;
            userAccount.CreatedOn = DateTime.UtcNow;
            await context.UserAccount.AddAsync(userAccount);
            await context.SaveChangesAsync();
            return (Guid)userAccount.UserId;
        }

        /// <summary>
        /// ValidateUserCredentialAsync Method to check user credential and validate user identity in the DB
        /// </summary>
        /// <param name="userCredentail"></param>
        /// <returns>userId</returns>
        public async Task<Guid?> ValidateUserCredentialAsync(UserAccount userCredentail)
        {
            return await context.UserAccount.Where(user => user.EmailId == userCredentail.EmailId && user.Password == userCredentail.Password).
                Select(select => select.UserId).SingleOrDefaultAsync();
        }

        /// <summary>
        /// ForgotPasswordAsync Method to check user credential and return Password
        /// </summary>
        /// <param name="userCredentail"></param>
        /// <returns>password</returns>
        public async Task<string> ForgotPasswordAsync(UserAccount userCredentail)
        {
            return await context.UserAccount.Where(user => user.EmailId == userCredentail.EmailId && user.SecretCode == userCredentail.SecretCode).
                Select(select => select.Password).SingleOrDefaultAsync();
        }

        /// <summary>
        /// CheckExistingEmailIdAsync Method to check Email Id already exist in Database
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns>bool</returns>
        public async Task<bool> CheckEmailIdExistAsync(string emailId)
        {
            return await context.UserAccount.AnyAsync(user => user.EmailId == emailId);
        }
        #endregion
    }
}
