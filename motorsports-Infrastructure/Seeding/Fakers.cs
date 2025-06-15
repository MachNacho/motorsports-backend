using Bogus;
using motorsports_Domain.Entities;
using motorsports_Domain.enums;

namespace motorsports_Infrastructure.Seeding
{
    public class Fakers
    {
        Faker<DriverEntity> _driverFaker = null;
        Faker<TeamEntity> _teamFaker = null;

        readonly List<string> _teamSuffixes = new()
        {
            "Racing",
            "Autosport",
            "Motorsport",
            "Sportcar",
            "Team",
            "Racing Team",
            "Performance",
            "Speedworks",
            "Raceworks",
            "GP",            
            "Sport",
            "Garage",
            "Engineering",
            "Competition",
            "Motors",
            "Motorsports",
            "Dynamics",
            "Power",
            "Tuning",
            "Development",
            "Racing Division",
            "Race Engineering",
            "Global",
            "Enterprise",
            "International",
            "Corsa",

        };


        private static int seed = 1534; // Example seed value

        public Faker<DriverEntity> GetFakeDrivers()
        {
            if (_driverFaker == null)
            {
                _driverFaker = new Faker<DriverEntity>()
                    .UseSeed(seed)
                    .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                    .RuleFor(p => p.MiddleName, f => f.Random.Bool(0.5f) ? f.Name.FirstName() : null)
                    .RuleFor(p => p.LastName, f => f.Name.LastName())
                    .RuleFor(p => p.BirthDate, f => DateOnly.FromDateTime(f.Date.Between(DateTime.Now.AddYears(-70), DateTime.Now.AddYears(-18))))
                    .RuleFor(p => p.Gender, f => f.PickRandom<GenderEnum>())
                    .RuleFor(p => p.RaceNumber, f =>  f.Random.Int(1, 99))
                    .RuleFor(p => p.ImageUrl, f => f.Random.Bool(0.5f) ? f.Internet.Avatar() : null)
                    .RuleFor(p => p.Description, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence() : null);
            }

            return _driverFaker;
        }

        public Faker<TeamEntity> GetFakeTeams()
        {
            if (_teamFaker == null)
            {
                _teamFaker = new Faker<TeamEntity>()
                    .UseSeed(seed)
                    .RuleFor(p => p.TeamName, f =>
                    {
                        var baseName = f.Company.CompanyName();
                        var suffix = f.PickRandom(_teamSuffixes);
                        return $"{baseName} {suffix}";
                     })
                    .RuleFor(p => p.YearFounded,f=> DateOnly.FromDateTime(f.Date.Between(new DateTime(1920, 1, 1), DateTime.Now)));      
            }

            return _teamFaker;
        }
    }
}
