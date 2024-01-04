using PHE2.Contratcs;
using PHE2.Data;
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.Repositoreis
{
    public class ProjectRepository : GeneralRepository<Project>, IProjectRepository
    {
        public ProjectRepository(Phe2DbContext context) : base(context) { }
    }
}