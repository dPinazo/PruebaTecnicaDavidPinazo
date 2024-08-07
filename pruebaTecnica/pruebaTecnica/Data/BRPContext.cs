using Microsoft.EntityFrameworkCore;
using pruebaTecnica.Models;

namespace pruebaTecnica.Data
{
    public class BRPContext : DbContext
    {
        public BRPContext(DbContextOptions<BRPContext> options) : base(options) { }

        public DbSet<BRP> BRPs { get; set; }
    }
}
