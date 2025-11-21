using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Driver;

namespace motorsports_Service.Helpers
{
    public static class DriverUpdateHelper
    {
        public static void ApplyDriverUpdates(DriverEntity driver, UploadDriverDTO dto)
        {
            if (driver.FirstName != dto.FirstName) driver.FirstName = dto.FirstName;
            if (driver.MiddleName != dto.MiddleName) driver.MiddleName = dto.MiddleName;
            if (driver.LastName != dto.LastName) driver.LastName = dto.LastName;
            if (driver.BirthDate != dto.BirthDate) driver.BirthDate = (DateOnly)dto.BirthDate;
            if (driver.RaceNumber != Convert.ToInt32(dto.RaceNumber)) driver.RaceNumber = Convert.ToInt32(dto.RaceNumber);
            if (driver.Gender != dto.Gender) driver.Gender = (motorsports_Domain.Constants.Constants.GenderEnum)dto.Gender;
            if (driver.NationalityId != dto.NationalityID) driver.NationalityId = (Guid)dto.NationalityID;
            if (driver.TeamId != dto.TeamID) driver.TeamId = dto.TeamID;
            if (driver.Description != dto.Description) driver.Description = dto.Description;
        }
    }
}
