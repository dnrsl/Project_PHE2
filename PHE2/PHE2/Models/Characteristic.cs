using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PHE2.Models
{
    [Table("tb_m_characteristics")]
    public class Characteristic : BaseEntity
    {
        [Column("business_field")]
        public string BusinessField { get; set; }

        [Column("company_type")]
        public string CompanyType { get; set; }

        //Cardinality
        public Account Account { get; set; }
    }
}