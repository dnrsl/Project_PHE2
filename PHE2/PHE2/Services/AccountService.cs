
using PHE2.Contratcs;
using PHE2.DTOs.Accounts;
using PHE2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PHE2.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            var accounts = _accountRepository.GetAll();
            if (!accounts.Any())
            {
                return Enumerable.Empty<AccountDto>();
            }

            var accountDtos = new List<AccountDto>();
            foreach (var account in accounts)
            {
                accountDtos.Add((AccountDto)account);
            }
            return accountDtos;
        }

        public AccountDto GetByGuid(Guid guid)
        {
            var accountDto = _accountRepository.GetByGuid(guid);
            if (accountDto is null)
            {
                return null;
            }
            return (AccountDto)accountDto;
        }

        public AccountDto Create(NewAccountDto newAccountDto)
        {
            var accountDto = _accountRepository.Create(newAccountDto);
            if (accountDto is null)
            {
                return null;
            }
            return (AccountDto)accountDto;

        }

        public int Update(AccountDto accountDto)
        {
            var account = _accountRepository.GetByGuid(accountDto.Guid);
            if (account is null)
            {
                return -1;
            }
            Account toUpdate = accountDto;
            toUpdate.CreatedDate = account.CreatedDate;
            var result = _accountRepository.Update(toUpdate);

            return result ? 1 : 0;
        }

        public int Delete(Guid guid)
        {
            var account = _accountRepository.GetByGuid(guid);
            if (account is null)
            {
                return -1;
            }

            var result = _accountRepository.Delete(account);
            return result ? 1 : 0;
        }
    }
}