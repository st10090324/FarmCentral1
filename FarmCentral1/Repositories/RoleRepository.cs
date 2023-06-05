using FarmCentral1.Areas.Identity.Data;
using FarmCentral1.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FarmCentral1.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
