using motorsports_Domain.Entities.@base;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Domain.Entities
{
    public class RaceTrackEntity : BaseEntity
    {
        public string Circuit { get; set; }
        public TrackTypeEnum Type { get; set; }
        public TrackDirectionEnum Direction { get; set; }
        public string Location { get; set; }
        public string Last_length_used { get; set; }
        public string Turns { get; set; }
        public string Grand_Prix_Names { get; set; }
        public Guid NationID { get; set; }
        public NationalityEntity nation { get; set; }
    }
}
