using FarmCentral1.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmCentral1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("RoleId")]
        public string RoleId { get; set; }
        public ApplicationUser Role { get; set; }
    }
}
