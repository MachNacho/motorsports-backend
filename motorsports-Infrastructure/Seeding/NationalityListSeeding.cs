using motorsports_Domain.Entities;
using motorsports_Infrastructure.Seeding.Models;
using System.Text.Json;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Infrastructure.Seeding
{
    public class NationalityListSeeding
    {
        public static List<NationalityEntity> CountryList()
        {
            string jsonPath = AppDomain.CurrentDomain.BaseDirectory + "Seeding\\Data\\Nations.json";
            string content = File.ReadAllText(jsonPath);

            var nationListWrapper = JsonSerializer.Deserialize<NationsWrapper>(content);
            var nations = nationListWrapper.Nations.Select(dto => new NationalityEntity
            {
                Name = dto.Name,
                Capital = dto.Capital,
                Continent = ParseContinent(dto.Continent),
                FlagOneByOne = dto.FlagOneByOne,
                FlagFourByThree = dto.FlagFourByThree,
                IsIso = dto.IsIso,
                Code = dto.Code,
            }).ToList();

            return nations;
        }
        public class NationsWrapper
        {
            public List<NationalitySeedDto> Nations { get; set; }
        }
        private static ContinentEnum ParseContinent(string? continentString)
        {
            if (string.IsNullOrWhiteSpace(continentString))
                return ContinentEnum.Other;

            return Enum.TryParse<ContinentEnum>(
                continentString.Trim().Replace(' ', '_'),
                ignoreCase: true,
                out var continent
            ) ? continent : ContinentEnum.Other;
        }
    }
}
