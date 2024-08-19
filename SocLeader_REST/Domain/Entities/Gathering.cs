namespace SocLeader_REST.Domain.Entities
{
    public class Gathering
    {
        public static Gathering Empty = new Gathering();
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime StartTime { get; set; }
        public Guid OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public GatheringType Type { get; set; }
        public long Lat {  get; set; }
        public long Lon { get; set; }
        public virtual ICollection<AppUser> Participants { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public enum GatheringType
        {
            Free = 0,
            Paid = 1
        }
    }
}
