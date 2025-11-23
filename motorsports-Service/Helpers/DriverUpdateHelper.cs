using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Driver;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Service.Helpers
{
    public static class DriverUpdateHelper
    {
        public static void ApplyDriverUpdates(DriverEntity driver, UploadDriverDTO dto)
        {
            if (driver.FirstName != dto.FirstName) 
                driver.FirstName = dto.FirstName;

            if (driver.MiddleName != dto.MiddleName) 
                driver.MiddleName = dto.MiddleName;

            if (driver.LastName != dto.LastName) 
                driver.LastName = dto.LastName;

            if (driver.BirthDate != dto.BirthDate) 
                driver.BirthDate = (DateOnly)dto.BirthDate;

            if (!string.IsNullOrEmpty(dto.RaceNumber))
            {
                var raceNumber = Convert.ToInt32(dto.RaceNumber);
                if (driver.RaceNumber != raceNumber) driver.RaceNumber = raceNumber;
            }

            if (driver.Gender != dto.Gender) 
                driver.Gender = (GenderEnum)dto.Gender;

            if (driver.NationalityId != dto.NationalityID) 
                driver.NationalityId = (Guid)dto.NationalityID;

            if (driver.TeamId != dto.TeamID) 
                driver.TeamId = dto.TeamID;

            if (driver.Description != dto.Description) 
                driver.Description = dto.Description;

            // Numeric stats
            driver.RacesParticipated = ParseIntOrDefault(dto.RacesParticipated, driver.RacesParticipated);
            driver.RacePodiums = ParseIntOrDefault(dto.RacePodiums, driver.RacePodiums);
            driver.RaceWins = ParseIntOrDefault(dto.RaceWins, driver.RaceWins);
            driver.ChampionshipTitles = ParseIntOrDefault(dto.ChampionshipTitles, driver.ChampionshipTitles);
            driver.RacePole = ParseIntOrDefault(dto.RacePole, driver.RacePole);
            driver.CareerPoints = ParseIntOrDefault(dto.CareerPoints, driver.CareerPoints);
            driver.RaceLapsLed = ParseIntOrDefault(dto.RaceLapsLed, driver.RaceLapsLed);
        }

        private static int ParseIntOrDefault(string? value, int current)
        {
            return int.TryParse(value, out int result) ? result : current;
        }
    }
}
