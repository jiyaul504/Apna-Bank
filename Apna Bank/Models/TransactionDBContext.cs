using Microsoft.EntityFrameworkCore;

namespace Apna_Bank.Models
{
    public class TransactionDBContext:DbContext
    {
        public TransactionDBContext(DbContextOptions<TransactionDBContext>options) : base(options)
        {

        }
        public DbSet<TransactionModel> Transactioncs { get; set; }
    }
}
