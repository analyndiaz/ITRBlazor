using System.ComponentModel.DataAnnotations.Schema;

namespace Evolve.ITR.TitleQuest.Entities.vianac
{
    [Table("ttl_prereq_provider", Schema = "vianac")]
    public class PreRequisiteProvider
    {
        public int ttl_prereq_provider_cd { get; set; }
        public string ttl_prereq_provider_desc { get; set; }
        public virtual List<PreRequisite> PreRequisites { get; protected set; }
    }
}
