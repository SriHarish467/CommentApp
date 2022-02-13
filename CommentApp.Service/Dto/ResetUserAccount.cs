using System.ComponentModel.DataAnnotations;



namespace CommentApp.Service.Dto
{
    public class RestUserAccountDto
    {
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string SecretCode { get; set; }
    }
}
