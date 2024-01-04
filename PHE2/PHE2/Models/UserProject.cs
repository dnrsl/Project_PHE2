using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PHE2.Models
{
    [Table("tb_tr_user_projects")]
    public class UserProject : BaseEntity
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("project_guid")]
        public Guid ProjectGuid { get; set; }

        //Cardinality
        public User User { get; set; }
        public Project Project { get; set; }
    }
}