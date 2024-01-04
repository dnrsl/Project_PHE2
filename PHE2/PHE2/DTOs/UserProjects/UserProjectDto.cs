
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.DTOs.UserProjects
{
    public class UserProjectDto
    {
        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public Guid ProjectGuid { get; set; }

        public static implicit operator UserProject(UserProjectDto dto)
        {
            return new UserProject
            {
                Guid = dto.Guid,
                UserGuid = dto.UserGuid,
                ProjectGuid = dto.ProjectGuid,
                ModifiedDate = DateTime.Now,
            };
        }

        public static explicit operator UserProjectDto(UserProject userProject)
        {
            return new UserProjectDto
            {
                Guid = userProject.Guid,
                UserGuid = userProject.UserGuid,
                ProjectGuid = userProject.ProjectGuid,
            };
        }
    }
}