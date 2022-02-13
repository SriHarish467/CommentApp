using CommentApp.Service.Dto;
using CommentApp.Service.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace CommentApp.Controllers
{
    [ApiController]
    [Route("api/comment")]
    [Authorize]
    public class CommentController : ControllerBase
    {
        #region Members
        private readonly ICommentService service;
        #endregion

        #region Constructor
        public CommentController(ICommentService _service)
        {
            service = _service;
        }
        #endregion

        #region API Methods
        /// <summary>
        /// GetCommentDetails API to fectch list of comments entity
        /// </summary>
        /// <returns>List of Comments in object</returns>
        [HttpGet]
        public async Task<IActionResult> GetCommentDetails()
        {
            var commentDetails = await service.GetCommentDetailsAsync();
            return Ok(commentDetails);
        }

        /// <summary>
        /// GetCommentDetailsByUserId API to fetch an list of comments entity by given UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Comments of specific user in object</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentDetailsByUserId(Guid id)
        {
            if (id != Guid.Empty)
            {
                var commentDetail = await service.GetCommentDetailsByUserIdAsync(id);
                return Ok(commentDetail);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// CreateComment API to create an comment entity
        /// </summary>
        /// <param name="commentDetailDto"></param>
        /// <returns>Status ok</returns>
        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentDto commentDetailDto)
        {
            //Check entity param is valid
            if (ModelState.IsValid)
            {
                await service.CreateCommentAsync(commentDetailDto);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
