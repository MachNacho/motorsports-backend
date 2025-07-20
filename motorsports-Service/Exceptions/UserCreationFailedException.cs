using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Service.Exceptions
{
    public class UserCreationFailedException:Exception
    {
        public UserCreationFailedException(string message) : base(message) { }
    }
}
