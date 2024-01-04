
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.DTOs.Projects
{
    public class NewProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserGuid { get; set; }

        public static implicit operator Project(NewProjectDto dto)
        {
            return new Project
            {
                Guid = new Guid(),
                Name = dto.Name,
                Description = dto.Description,
                UserGuid = dto.UserGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }
}