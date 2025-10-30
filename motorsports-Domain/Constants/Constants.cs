namespace motorsports_Domain.Constants
{
    public class Constants
    {
        // Default role assigned to new users
        public const string DEFAULT_USER_ROLE = "User";

        public static class CacheKeys
        {
            public const string Drivers = "Drivers";
            public const string Nations = "Nations";
        }
        public enum ContinentEnum
        {
            Africa,
            Antarctica,
            Asia,
            Europe,
            North_America,
            Oceania,
            South_America,
            Other
        }
        public enum GenderEnum
        {
            Male = 1,
            Female = 2,
            Other = 3
        }

        /// <summary>
        /// Defines the direction in which the track runs.
        /// </summary>
        public enum TrackDirectionEnum
        {
            Clockwise,
            AntiClockwise,
            Mixed
        }

        /// <summary>
        /// Defines the type of the track.
        /// </summary>
        public enum TrackTypeEnum
        {
            Street_Circuit,
            Road_Circuit,
            Race_Circuit,
            Other
        }
    }
}
