using System.ComponentModel.DataAnnotations.Schema;

namespace Evolve.ITR.TitleQuest.Entities.vianac
{
    [Table("ttl_prereq_dims", Schema = "vianac")]
    public class PreRequisiteDimension
    {
        public int xref_row_id { get; set; }
        public int ttl_preqeq_id { get; set; }
        public string prod_class { get; set; }
        public string contract_cd { get; set; }
        public string engine_typ { get; set; }
        public int? gvw_from { get; set; }
        public int? gvw_to { get; set; }
        public int? model_yr_back { get; set; }
        public string county { get; set; }
        public string city { get; set; }
        public int? model_yr_forward { get; set; }
        public string cli_no { get; set; }
        public string bkdn { get; set; }
        public string fin_src { get; set; }
        public int? active_ind { get; set; }
        public string from_model_yr { get; set; }
        public string to_model_yr { get; set; }
        public virtual PreRequisite PreRequisite { get; protected set; }
    }
}
