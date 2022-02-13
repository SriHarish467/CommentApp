using AutoMapper;
using CommentApp.Domain.Model;
using CommentApp.Repository.RepositoryInterface;
using CommentApp.Service.Dto;
using CommentApp.Service.Helpers.AuthenticationManager;
using CommentApp.Service.ServiceInterface;
using System;
using System.Threading.Tasks;



namespace CommentApp.Service.Service
{
    public class UserAccountService: IUserAccountService
    {
        #region Members
        private readonly IUserAccountRepository repository;
        private readonly IMapper mapper;
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        #endregion

        #region Constructor
        public UserAccountService(IUserAccountRepository _repository, IMapper _mapper, IJWTAuthenticationManager _jwtAuthenticationManager)
        {
            repository = _repository;
            mapper = _mapper;
            jwtAuthenticationManager = _jwtAuthenticationManager;
        }
        #endregion

        #region Service Methods
        /// <summary>
        /// CreateNewUserAccountAsync Method to create New User Account in the DB
        /// </summary>
        /// <param name="newUserAccountDto"></param>
        /// <returns>JWT token</returns>
        public async Task<string> CreateNewUserAccountAsync(NewUserAccountDto newUserAccountDto)
        {
            //AutoMapper to convert DTO Object to Model Object
            var newUserCredentail = mapper.Map<UserAccount>(newUserAccountDto);
            var userId = await repository.CreateNewUserAccountAsync(newUserCredentail);
            return jwtAuthenticationManager.GenerateJSONWebToken((Guid)userId);
        }

        /// <summary>
        /// ValidateUserCredentialAsync Method to check user credential and validate user identity in the system
        /// </summary>
        /// <param name="loginCredentail"></param>
        /// <returns>JWT token</returns>
        public async Task<string> ValidateUserCredentialAsync(LoginDto loginCredentail)
        {
            var userCredentail = mapper.Map<UserAccount>(loginCredentail);
            var userId = await repository.ValidateUserCredentialAsync(userCredentail);
           
            if(userId == null)
            {
                return null;
            }
            else
            {
                return jwtAuthenticationManager.GenerateJSONWebToken((Guid)userId);
            }
        }

        /// <summary>
        /// ForgotPasswordAsync Method to check user credential and return Password
        /// </summary>
        /// <param name="restUserAccountDto"></param>
        /// <returns>password</returns>
        public async Task<string> ForgotPasswordAsync(RestUserAccountDto restUserAccountDto)
        {
            var restUserAccount = mapper.Map<UserAccount>(restUserAccountDto);
            var password = await repository.ForgotPasswordAsync(restUserAccount);
            return password;
        }
        #endregion
    }
}
