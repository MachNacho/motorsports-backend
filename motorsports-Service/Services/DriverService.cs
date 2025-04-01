using AutoMapper;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Domain.enums;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs;

namespace motorsports_Service.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ICacheRepository _cacheService;
        private readonly IMapper _mapper;
        const string cacheKey = "drivers_list";

        public DriverService(IDriverRepository driverRepository, ICacheRepository cacheService, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _cacheService = cacheService;
            _mapper = mapper;
        }
        public async Task<string> CreateDriver(DriverDTO driverDTO)
        {
            var driver = _mapper.Map<Driver>(driverDTO);
            await _cacheService.RemoveAsync(cacheKey);
            return await _driverRepository.CreateDriver(driver);
        }

        public Task<Driver> DeleteDriver(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DriverDTO>> GetAllDrivers()
        {

            var cachedDrivers = await _cacheService.GetAsync<IEnumerable<DriverDTO>>(cacheKey);
            if (cachedDrivers != null)
            {
                Console.WriteLine("from Cache");
                return cachedDrivers;
            }
            Console.WriteLine("in service");
            var drivers = await _driverRepository.GetAllDrivers();
            var A = drivers.Select(D => new DriverDTO
            {
                FirstName = D.FirstName,
                LastName = D.LastName,
                BirthDate = D.BirthDate,
                Nationality = ((NationalityEnums)D.Nationality).ToString().Replace("_", " "),
                Gender = ((GenderEnums)D.Gender).ToString().Replace("_", " ")
            });
            Console.WriteLine("Cached");
            await _cacheService.SetAsync(cacheKey, A);

            return A;
        }

        public Task<Driver> GetDriverById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
