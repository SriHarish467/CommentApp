using AutoMapper;
using CommentApp.Domain.Model;
using CommentApp.Repository.RepositoryInterface;
using CommentApp.Service.Dto;
using CommentApp.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CommentApp.Service.Service
{
    public class CommentService:ICommentService
    {
        #region Members
        private readonly ICommentRepository repository;
        private readonly IMapper mapper;
        #endregion

        #region Constructor
        public CommentService(ICommentRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        #endregion

        #region Service Methods

        /// <summary>
        /// GetCommentDetailsAsync Method to fectch list of comments connect with repository
        /// </summary>
        /// <returns>List of Comments in object</returns>
        public async Task<List<CommentDto>> GetCommentDetailsAsync()
        {
            var comment = await repository.GetCommentDetailsAsync();

            //AutoMapper to convert Model Object to DTO Object
            return mapper.Map<List<CommentDto>>(comment);
        }

        /// <summary>
        /// GetCommentDetailsByUserIdAsync Method to fetch an list of comments entity by given UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of Comments of specific user in object</returns>
        public async Task<List<CommentDto>> GetCommentDetailsByUserIdAsync(Guid userId)
        {
            var comment = await repository.GetCommentDetailsByUserIdAsync(userId);
            return mapper.Map<List<CommentDto>>(comment);
        }

        /// <summary>
        /// CreateCommentAsync Method to create an comment in DB
        /// </summary>
        /// <param name="commentDetailDto"></param>
        public async Task CreateCommentAsync(CommentDto commentDetailDto)
        {
            var commentDetail = mapper.Map<Comment>(commentDetailDto);
            await repository.CreateCommentAsync(commentDetail);
        }
        #endregion
    }
}
