using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CommentApp.Domain.Model
{
    public class Comment
    {
        public Guid? CommentId { get; set; }
        public string CommentDescription { get; set; }
        [Display(Name="UserAccount")]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserAccount UserAccount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
