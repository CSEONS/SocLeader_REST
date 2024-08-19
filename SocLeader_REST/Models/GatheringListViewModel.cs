using static SocLeader_REST.Domain.Entities.Gathering;

namespace SocLeader_REST.Models
{
    public class GatheringListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public GatheringType Type { get; set; }
        public DateTime StartTime { get; set; }
    }
}
