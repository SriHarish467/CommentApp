using System;
using System.ComponentModel.DataAnnotations;



namespace CommentApp.Service.Dto
{
    public class CommentDto
    {
        [Required]
        public string CommentDescription { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public UserDetailDto UserAccount { get; set; }
    }
}
