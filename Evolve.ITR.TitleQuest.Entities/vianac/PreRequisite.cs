using Evolve.ITR.ServiceContract.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evolve.ITR.TitleQuest.Entities.vianac
{
    [Table("ttl_prereqs", Schema = "vianac")]
    public class PreRequisite
    {
        public int ttl_preqeq_id { get; set; }
        public string prereq_short_desc { get; set; }
        public string prereq_long_desc { get; set; }
        public string state_abbr { get; set; }
        public bool original_required { get; set; }
        public string prereq_int_comment { get; set; }
        public int? ttl_prereq_provider_cd { get; set; }
        public PreRequisiteProvider Provider { get; set; }
        public virtual List<PreRequisiteDimension> Dimensions { get; protected set; }
        public PreRequisiteDTO ToDTO()
        {
            return new PreRequisiteDTO
            {
                Id = ttl_preqeq_id,
                ShortDescription = prereq_short_desc,
                LongDescription = prereq_long_desc,
                State = state_abbr,
                OriginalRequired = original_required,
                Comment = prereq_int_comment,
                Provider = Provider?.ttl_prereq_provider_desc,
                //Dimensions = Dimensions != null && TitleQuestPreRequisiteDimensions.Any()
                //                ? TitleQuestPreRequisiteDimensions.Select(d => d.ToDTO()).ToList()
                //                : new List<PreRequisiteDimensionDTO>()
            };
        }

    }
}
