using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Service.Exceptions
{
    public class RoleUpdateException:Exception
    {
        public RoleUpdateException(string message) : base($"Failed to update user role: {message}") { }
    }
}
