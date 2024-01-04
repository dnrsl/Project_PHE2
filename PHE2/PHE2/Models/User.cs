using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PHE2.Models
{
    [Table("tb_m_users")]
    public class User : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("email", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("telephone")]
        public string Telephone { get; set; }

        [Column("photo")]
        public string Photo { get; set; }

        //Cardinality
        public Account Account { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<UserProject> UserProjects { get; set; }
    }
}