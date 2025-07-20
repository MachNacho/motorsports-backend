using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Service.Exceptions
{
    public class RoleNotFoundException:Exception
    {
        public RoleNotFoundException(string roleName) : base($"Role '{roleName}' does not exist.") { }
    }
}
