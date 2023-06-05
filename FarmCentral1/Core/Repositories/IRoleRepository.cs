using FarmCentral1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace FarmCentral1.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
