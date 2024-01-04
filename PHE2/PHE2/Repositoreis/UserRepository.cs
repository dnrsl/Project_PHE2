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
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(Phe2DbContext context) : base(context) { }

        public User GetByEmail(string email)
        {
            return _context.Set<User>()
                           .SingleOrDefault(u => u.Email.Contains(email));
        }
    }
}