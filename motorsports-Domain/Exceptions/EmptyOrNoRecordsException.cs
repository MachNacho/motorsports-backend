using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Domain.Exceptions
{
    public class EmptyOrNoRecordsException:Exception
    {
        public EmptyOrNoRecordsException(string message) : base(message) { }
    }
}
