using motorsports_Domain.Entities;
using motorsports_Infrastructure.Seeding.Models;
using System.Text.Json;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Infrastructure.Seeding
{
    public class TrackListSeeding
    {
        public static List<RaceTrackEntity> TrackList(List<NationalityEntity> nations)
        {
            string jsonPath = AppDomain.CurrentDomain.BaseDirectory + "Seeding\\Data\\Tracks.json";
            string content = File.ReadAllText(jsonPath);

            var TrackWrapper = JsonSerializer.Deserialize<List<TrackSeedDTO>>(content);

            var tracks = TrackWrapper.Select(dto =>
            {
                var nation = nations.FirstOrDefault(n => string.Equals(n.Name, dto.Country, StringComparison.OrdinalIgnoreCase));
                return new RaceTrackEntity
                {
                    Grand_Prix_Names = dto.GrandsPrix,
                    Circuit = dto.Circuit.Replace("*", string.Empty),
                    Type = TrackTypeEnumFinder(dto.Type),
                    Direction = TrackEnumFinder(dto.Direction),
                    Location = dto.Location,
                    Last_length_used = dto.LastLengthUsed,
                    Turns = dto.Turns,
                    NationID = nation.Id
                };

            }).ToList();

            return tracks;
        }

        private static TrackDirectionEnum TrackEnumFinder(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return TrackDirectionEnum.Mixed;
            switch (value.Trim().ToLowerInvariant())
            {
                case "clockwise":
                    return TrackDirectionEnum.Clockwise;
                case "anti-clockwise" or "anticlockwise":
                    return TrackDirectionEnum.AntiClockwise;
                default:
                    return TrackDirectionEnum.Mixed;

            }
        }

        private static TrackTypeEnum TrackTypeEnumFinder(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return TrackTypeEnum.Other;
            switch (value.Trim())
            {
                case "Street circuit":
                    return TrackTypeEnum.Street_Circuit;
                case "Road circuit":
                    return TrackTypeEnum.Road_Circuit;
                case "Race circuit":
                    return TrackTypeEnum.Race_Circuit;
                default:
                    return TrackTypeEnum.Other;

            }
        }
    }
}
