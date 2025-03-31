namespace motorsports_Domain.Entities.@base
{
    public class baseEntity
    {
        public int ID { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        public bool isActive { get; set; }
    }
}
