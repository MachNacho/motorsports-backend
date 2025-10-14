using motorsports_Infrastructure.Data;

namespace motorsports_Infrastructure.Seeding
{
    public static class DbSeeder
    {
        public static void SeedBDData(ApplicationDBContext context, Fakers fakers, int driverCount = 1, int teamCount = 1)
        {
            ClearDatabase(context);
            SeedData(context, fakers, driverCount, teamCount);
        }
        public static void ClearDatabase(ApplicationDBContext context)
        {
            context.RemoveRange(context.Driver);
            context.RemoveRange(context.Team);
            context.RemoveRange(context.Nationailty);
            context.SaveChanges();
        }
        public static void SeedData(ApplicationDBContext context, Fakers fakers, int driverCount, int teamCount)
        {
            var personList = fakers.GetFakeDrivers().Generate(driverCount);
            var teamList = fakers.GetFakeTeams().Generate(teamCount);
            var rand = new Random();

            //Nation seeding
            var nationsList = NationalityListSeeding.CountryList();
            context.Nationailty.AddRange(nationsList);
            //Only nation that are part of the International Organization for Standardization list (ISO 3166)
            var isIsoNationList = nationsList.Where(x => x.IsIso == true).ToList();
            //Team seeding
            foreach (var r in teamList)
            {
                r.NationalityId = isIsoNationList[rand.Next(isIsoNationList.Count - 1)].Id;
            }
            context.Team.AddRange(teamList);

            //Driver seeding
            foreach (var r in personList)
            {
                r.NationalityId = isIsoNationList[rand.Next(isIsoNationList.Count - 1)].Id;
                r.TeamId = teamList[rand.Next(teamList.Count - 1)].Id;
            }
            context.Driver.AddRange(personList);

            context.SaveChanges();
        }
    }
}
