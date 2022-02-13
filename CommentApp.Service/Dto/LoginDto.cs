using System.ComponentModel.DataAnnotations;



namespace CommentApp.Service.Dto
{
    public class LoginDto
    {
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
