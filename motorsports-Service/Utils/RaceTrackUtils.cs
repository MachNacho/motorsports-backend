namespace motorsports_Service.Utils
{
    public class RaceTrackUtils
    {
        public static List<string> ParseGrandPrixNames(string? grandPrixNames)
        {
            if (string.IsNullOrWhiteSpace(grandPrixNames))
                return new List<string>();

            // Split on commas, trim whitespace, remove empty entries
            return grandPrixNames
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(name => name.Trim())
                .ToList();
        }
    }
}
