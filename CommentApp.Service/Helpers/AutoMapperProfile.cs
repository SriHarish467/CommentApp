using AutoMapper;
using CommentApp.Domain.Model;
using CommentApp.Service.Dto;


namespace CommentApp.Service.Helpers
{
    public class AutoMapperProfile : Profile
    {
        //AutoMapper use to convert Model to DTO object and DTO to Model object
        public AutoMapperProfile()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<UserAccount, NewUserAccountDto>().ReverseMap();
            CreateMap<UserAccount, LoginDto>().ReverseMap();
            CreateMap<UserAccount, RestUserAccountDto>().ReverseMap();
            CreateMap<UserAccount, UserDetailDto>().ReverseMap();
        }
    }
}
