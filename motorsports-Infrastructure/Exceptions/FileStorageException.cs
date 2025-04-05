using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Infrastructure.Exceptions
{
    public class FileStorageException: Exception
    {
        public FileStorageException(string message) : base(message) { }
    }
}
