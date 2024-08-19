namespace SocLeader_REST.Domain.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public static Tag Empty = new Tag();

        public static bool operator != (Tag left, Tag right)
        {
            return left.NormalizedName != right.NormalizedName;
        }

        public static bool operator == (Tag left, Tag right)
        {
            return left.NormalizedName == right.NormalizedName;
        }

        public static Tag Convert(string value)
        {
            return new Tag()
            {
                Id = Guid.NewGuid(),
                Name = value,
                NormalizedName = value.ToUpper()
            };
        }

        public static IEnumerable<Tag> Convert(IEnumerable<string> value)
        {
            List<Tag> result = new List<Tag>(value.Count());

            foreach (var item in value)
            {
                result.Add(Convert(item));
            }

            return result;
        }
    }
}
