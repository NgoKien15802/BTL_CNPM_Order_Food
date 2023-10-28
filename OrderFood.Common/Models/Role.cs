using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.Common.Models
{
    public class Role: BaseModel
    {
        [Key]
        public Guid RoleId { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "RoleName không được để trống.")]
        public string RoleName { get; set; } = "User";
    }
}
