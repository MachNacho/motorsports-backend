using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Domain.DTO.Account
{
    public class UpdateUserRoleDTO
    {
        public string UserId { get; set; }
        public string NewRole { get; set; }
    }
}
