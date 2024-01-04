using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.DTOs.Accounts
{
    public class NewAccountDto
    {
        public Guid Guid { get; set; }
        public string Password { get; set; }
        public int OTP { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool ApprovedByAdmin { get; set; }
        public bool ApprovedByManager { get; set; }

        public static implicit operator Account(NewAccountDto dto)
        {
            return new Account
            {
                Guid = dto.Guid,
                Password = dto.Password,
                OTP = dto.OTP,
                IsUsed = dto.IsUsed,
                ExpiredDate = dto.ExpiredDate,
                ApprovedByAdmin = dto.ApprovedByAdmin,
                ApprovedByManager = dto.ApprovedByManager,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}