using Microsoft.EntityFrameworkCore;

namespace Apna_Bank.Models
{
    public class TransactionDBContext:DbContext
    {
        public TransactionDBContext(DbContextOptions<TransactionDBContext>options) : base(options)
        {

        }
        public DbSet<Transactions> Transactioncs { get; set; }
    }
}
