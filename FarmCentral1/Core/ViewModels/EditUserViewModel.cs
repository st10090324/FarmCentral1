using FarmCentral1.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmCentral1.Core.ViewModels
{
    public class EditUserViewModel
    {   
        public ApplicationUser User { get; set; }

        public IList<SelectListItem> Roles { get; set; }
    }
}
