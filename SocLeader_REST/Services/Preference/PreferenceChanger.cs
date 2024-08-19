using SocLeader_REST.Domain.Entities;

namespace SocLeader_REST.Services.Preference
{
    public class PreferenceChanger : IPreferenceChanger
    {
        public void Change(ref AppUser user, IEnumerable<Tag> repositoryTags)
        {
            var preferenceTagsWeight = user.PreferencesWeight;

            var preferenceTags = preferenceTagsWeight.Select(p => p.Tag);

            foreach (var tag in repositoryTags)
            {
                if (preferenceTags.Contains(tag))
                {
                    var increasedTag = preferenceTagsWeight.First(p => p.Tag == tag);

                    increasedTag.Weigh++;
                    increasedTag.UnchangedIterationCount = 0;
                }

                preferenceTagsWeight.Add(new PreferencesTagWeight()
                {
                    Id = Guid.NewGuid(),
                    Owner = user,
                    OwnerId = user.Id,
                    Tag = tag,
                    TagId = tag.Id,
                    UnchangedIterationCount = 0,
                    Weigh = Config.TagDefaultWeight
                });
            }

            var deletingTags = new List<PreferencesTagWeight>();
            foreach (var prefrenceTag in preferenceTagsWeight)
            {
                if (prefrenceTag.UnchangedIterationCount > Config.CountOfDeleteUnchangedTag)
                    deletingTags.Add(prefrenceTag);
            }

            for (int i = 0; i < deletingTags.Count; i++)
            {
                preferenceTagsWeight.Remove(deletingTags[i]);
            }
        }
    }
}
