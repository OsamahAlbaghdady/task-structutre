using BackEndStructuer.Entities;

namespace e_parliament.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}