
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.DTOs.Roles
{
    public class DefaultRoleDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public static implicit operator Role(DefaultRoleDto dto)
        {
            return new Role
            {
                Guid = dto.Guid,
                Name = dto.Name,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }
}