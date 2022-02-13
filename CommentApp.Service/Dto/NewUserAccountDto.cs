using System.ComponentModel.DataAnnotations;



namespace CommentApp.Service.Dto
{
    public class NewUserAccountDto
    {
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string SecretCode { get; set; }
        
    }
}
