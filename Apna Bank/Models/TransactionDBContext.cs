using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Apna_Bank.Models
{
    public class TransactionDBContext:IdentityDbContext
    {
        public TransactionDBContext(DbContextOptions<TransactionDBContext>options) : base(options)
        {

        }
        public DbSet<TransactionModel> Transactioncs { get; set; }
    }
}
