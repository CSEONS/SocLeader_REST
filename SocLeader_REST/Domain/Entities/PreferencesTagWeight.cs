namespace SocLeader_REST.Domain.Entities
{
    public class PreferencesTagWeight
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
        public int UnchangedIterationCount { get; set; }
        public int Weigh { get; set; }
    }
}
