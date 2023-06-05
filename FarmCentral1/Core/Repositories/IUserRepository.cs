using FarmCentral1.Areas.Identity.Data;

namespace FarmCentral1.Core.Repositories
{
    public interface IUserRepository
    {

        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(String id);

        ApplicationUser UpdateUser(ApplicationUser user);

    }
}