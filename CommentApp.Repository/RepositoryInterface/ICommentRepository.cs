using CommentApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CommentApp.Repository.RepositoryInterface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentDetailsAsync();
        Task<List<Comment>> GetCommentDetailsByUserIdAsync(Guid userId);
        Task CreateCommentAsync(Comment comment);
    }
}
