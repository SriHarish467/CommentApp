using CommentApp.Domain.Context;
using CommentApp.Domain.Model;
using CommentApp.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CommentApp.Repository.Repository
{
    public class CommentRepository:ICommentRepository
    {
        #region Members
        private readonly CommentAppContext context;
        #endregion

        #region Constructor
        public CommentRepository(CommentAppContext _context)
        {
            context = _context;
        }
        #endregion

        #region Repository Methods

        /// <summary>
        /// GetCommentDetailsAsync Method fectch list of comments from DB using Context Instance
        /// </summary>
        /// <returns>List of Comments in object</returns>
        public async Task<List<Comment>> GetCommentDetailsAsync()
        {
            //Take only active comments and include UserAccount entity to get emailId with foreign key relationship 
            List<Comment> comment = await context.Comment.Where(comment => comment.IsActive == true).Include(x => x.UserAccount).ToListAsync();
            return comment;
        }

        /// <summary>
        /// GetCommentDetailsByUserIdAsync Method fectch list of comments of specific user from DB using Context Instance
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of Comments of specific user in object</returns>
        public async Task<List<Comment>> GetCommentDetailsByUserIdAsync(Guid userId)
        {
            //Take comments by specific userId and include UserAccount entity to get emailId with foreign key relationship
            List<Comment> commentDetail = await context.Comment.Where(comment => comment.UserId == userId).Include(x => x.UserAccount).ToListAsync();
            return commentDetail;
        }

        /// <summary>
        /// CreateCommentAsync Method to create an comment in DB
        /// </summary>
        /// <param name="comment"></param>
        public async Task CreateCommentAsync(Comment comment)
        {
            comment.IsActive = true;
            comment.CreatedOn = DateTime.UtcNow;
            await context.Comment.AddAsync(comment);
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
