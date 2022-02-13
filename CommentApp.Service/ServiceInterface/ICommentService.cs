using CommentApp.Service.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CommentApp.Service.ServiceInterface
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetCommentDetailsAsync();
        Task<List<CommentDto>> GetCommentDetailsByUserIdAsync(Guid userId);
        Task CreateCommentAsync(CommentDto commentDetailDto);
    }
}
