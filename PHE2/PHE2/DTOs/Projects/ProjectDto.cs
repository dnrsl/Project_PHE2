
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.DTOs.Projects
{
    public class ProjectDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserGuid { get; set; }

        public static implicit operator Project(ProjectDto dto)
        {
            return new Project
            {
                Guid = dto.Guid,
                Name = dto.Name,
                Description = dto.Description,
                UserGuid = dto.UserGuid,
                ModifiedDate = DateTime.Now
            };
        }

        public static explicit operator ProjectDto(Project project)
        {
            return new ProjectDto
            {
                Guid = project.Guid,
                Name = project.Name,
                Description = project.Description,
                UserGuid = project.UserGuid
            };
        }
    }
}