﻿
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.DTOs.UserProjects
{
    public class NewUserProjectDto
    {
        public Guid UserGuid { get; set; }
        public Guid ProjectGuid { get; set; }

        public static implicit operator UserProject(NewUserProjectDto dto)
        {
            return new UserProject
            {
                Guid = new Guid(),
                UserGuid = dto.UserGuid,
                ProjectGuid = dto.ProjectGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }

        public static explicit operator NewUserProjectDto(UserProject userProject)
        {
            return new NewUserProjectDto
            {
                UserGuid = userProject.UserGuid,
                ProjectGuid = userProject.ProjectGuid,
            };
        }
    }
}