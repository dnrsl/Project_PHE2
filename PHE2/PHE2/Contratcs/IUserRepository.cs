using PHE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHE2.Contratcs
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        User GetByEmail(string email);
    }
}
