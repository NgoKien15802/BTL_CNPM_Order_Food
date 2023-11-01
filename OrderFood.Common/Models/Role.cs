using System.ComponentModel.DataAnnotations;

namespace OrderFood.Common.Models
{
    public class Role: BaseModel
    {
        [Key]
        public Guid RoleId { get; set; } = Guid.NewGuid();

        public string RoleName { get; set; } = "User";
    }
}
