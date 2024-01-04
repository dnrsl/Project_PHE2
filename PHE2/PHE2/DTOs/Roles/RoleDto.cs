
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.DTOs.Roles
{
    public class RoleDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public static implicit operator Role(RoleDto dto)
        {
            return new Role
            {
                Guid = dto.Guid,
                Name = dto.Name,
                ModifiedDate = DateTime.Now
            };
        }

        public static explicit operator RoleDto(Role role)
        {
            return new RoleDto
            {
                Guid = role.Guid,
                Name = role.Name,
            };
        }
    }
}