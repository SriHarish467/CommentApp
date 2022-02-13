using System;


namespace CommentApp.Service.Helpers.AuthenticationManager
{
    public interface IJWTAuthenticationManager
    {
        string GenerateJSONWebToken(Guid UserId);
    }
}
