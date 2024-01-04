using PHE2.Contratcs;
using PHE2.Data;
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.Repositoreis
{
    public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepository(Phe2DbContext context) : base(context) { }

        public IEnumerable<string> GetRoleByAccountGuid(Guid guid)
        {
            var result = _context.Set<AccountRole>()
                                 .Where(ar => ar.AccountGuid == guid)
                                 .Include(ar => ar.Role)
                                 .Select(ar => ar.Role.Name);
            return result;
        }
    }
}