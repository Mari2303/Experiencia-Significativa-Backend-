using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Models.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IEmail;

namespace Repository.Implementations.Email
{
    public class PasswordRecoveryRepository : IPasswordRecoveryRepository
    {
        private readonly ApplicationContext _context;

        public PasswordRecoveryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PasswordRecovery recovery)
        {
            await _context.PasswordRecoveries.AddAsync(recovery);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordRecovery?> GetActiveRecoveryAsync(string email, string code)
        {
            return await _context.PasswordRecoveries
                .FirstOrDefaultAsync(r => r.Email == email && r.Code == code && r.Active);
        }

        public async Task DeactivateAsync(PasswordRecovery recovery)
        {
            recovery.Active = false;
            _context.PasswordRecoveries.Update(recovery);
            await _context.SaveChangesAsync();
        }
    }

}
