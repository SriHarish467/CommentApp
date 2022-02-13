using System;
using System.ComponentModel.DataAnnotations;


namespace CommentApp.Domain.Model
{
    public class UserAccount
    {
        [Key]
        public Guid? UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string SecretCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
