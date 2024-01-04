using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PHE2.Models
{
    [Table("tb_m_roles")]
    public class Role : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        //Cardinality
        public ICollection<AccountRole> AccountRoles { get; set; }
    }
}