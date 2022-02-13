using CommentApp.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace CommentApp.Domain.Context
{
    public class CommentAppContext: DbContext
    {
       
           //Get Connection string at runtime and help to connect to Database
            public CommentAppContext(DbContextOptions<CommentAppContext> options) : base(options)
            {
            }

            public DbSet<Comment> Comment { get; set; }
            public DbSet<UserAccount> UserAccount { get; set; }

    }
}
