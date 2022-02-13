using CommentApp.Service.Dto;
using CommentApp.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CommentApp.Controllers
{
    [ApiController]
    [Route("api/useraccount")]
    public class UserAccountController : ControllerBase
    {
        #region Members
        private readonly IUserAccountService service;
        #endregion

        #region Constructor
        public UserAccountController(IUserAccountService _service)
        {
            service = _service;
        }
        #endregion

        #region API Methods
        /// <summary>
        /// CreateNewUserAccount API to create New User Account in the DB
        /// </summary>
        /// <param name="newUserAccount"></param>
        /// <returns>JWT token</returns>
        [HttpPost("createaccount")]
        public async Task<IActionResult> CreateNewUserAccount(NewUserAccountDto newUserAccount)
        {
            //Check entity param is valid
            if (ModelState.IsValid)
            {
                var token = await service.CreateNewUserAccountAsync(newUserAccount);
                return Ok(new { token });
            }
            else
            {
                return BadRequest();
            }
             
        }

        /// <summary>
        /// ValidateUserCredential API to check user credential validate user identity and return proper status
        /// </summary>
        /// <param name="userCredentail"></param>
        /// <returns>JWT token,Unauthorized</returns>
        [HttpPost("login")]
        public async Task<IActionResult> ValidateUserCredential(LoginDto userCredentail)
        {
            if (ModelState.IsValid)
            {
                var token = await service.ValidateUserCredentialAsync(userCredentail);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(new { token });
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// ForgotPassword API to check user credential and return Password
        /// </summary>
        /// <param name="restPassword"></param>
        /// <returns>Password</returns>
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(RestUserAccountDto restPassword)
        {
            if (ModelState.IsValid)
            {
                var password = await service.ForgotPasswordAsync(restPassword);
                if(password ==null)
                {
                    return Unauthorized();
                }
                return Ok(new { password });
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
