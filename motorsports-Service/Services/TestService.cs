using motorsports_Domain.Exceptions;
using motorsports_Service.Contracts;
using motorsports_Service.Exceptions;

namespace motorsports_Service.Services
{
    public class TestService : ITestService
    {
        public Task ThrowException(int i)
        {
            switch (i)
            {
                case 1:
                    throw new DriveNotFoundException();
                case 2:
                    throw new RoleNotFoundException("s");
                case 3:
                    throw new DuplicateRecordException("");
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
