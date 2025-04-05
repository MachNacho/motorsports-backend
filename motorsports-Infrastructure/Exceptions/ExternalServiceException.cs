using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Infrastructure.Exceptions
{
    public class ExternalServiceException:Exception
    {
        public ExternalServiceException(string message) : base(message) { }
    }
}
