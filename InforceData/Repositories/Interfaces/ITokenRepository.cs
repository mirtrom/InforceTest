using Microsoft.AspNetCore.Identity;

namespace InforceData.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string GenerateToken(IdentityUser user, List<string> roles);
    }
}
