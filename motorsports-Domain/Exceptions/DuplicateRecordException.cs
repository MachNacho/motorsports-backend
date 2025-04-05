using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Domain.Exceptions
{
    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException(string message) : base(message) { }
    }
}
