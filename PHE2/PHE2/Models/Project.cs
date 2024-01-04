using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PHE2.Models
{
    [Table("tb_m_projects")]
    public class Project : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        //Cardinality
        public User User { get; set; }
        public ICollection<UserProject> UserProjects { get; set; }
    }
}