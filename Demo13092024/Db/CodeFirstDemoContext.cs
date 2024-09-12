using Demo13092024.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo13092024.Db
{
    public class CodeFirstDemoContext : DbContext
    {
        public CodeFirstDemoContext(DbContextOptions<CodeFirstDemoContext> options) : base(options) { }

        //Define table in db
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerInstrument> PlayersInstruments { get; set; }
        public DbSet<InstrumentType> Instruments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Instruments)
                .WithOne();
            modelBuilder.Seed();
        }
    }
}
