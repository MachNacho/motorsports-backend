using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Driver;

namespace motorsports_Service.Helpers
{
    public static class DriverUpdateHelper
    {
        public static void ApplyDriverUpdates(DriverEntity driver, UpdateDriverDTO dto)
        {
            if (driver.FirstName != dto.FirstName) driver.FirstName = dto.FirstName;
            if (driver.MiddleName != dto.MiddleName) driver.MiddleName = dto.MiddleName;
            if (driver.LastName != dto.LastName) driver.LastName = dto.LastName;
            if (driver.BirthDate != dto.BirthDate) driver.BirthDate = (DateOnly)dto.BirthDate;
            if (driver.RaceNumber != dto.RaceNumber) driver.RaceNumber = dto.RaceNumber;
            if (driver.Gender != dto.Gender) driver.Gender = (motorsports_Domain.Constants.Constants.GenderEnum)dto.Gender;
            if (driver.NationalityId != dto.NationalityId) driver.NationalityId = (Guid)dto.NationalityId;
            if (driver.TeamId != dto.TeamId) driver.TeamId = dto.TeamId;
        }
    }
}
