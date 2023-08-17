
using Date.Models;

namespace Date.Interfaces
{
    public interface ITokenService
    {
        string CreatToken(AppUser user);
    }
}