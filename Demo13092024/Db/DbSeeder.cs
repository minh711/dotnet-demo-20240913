using Demo13092024.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Demo13092024.Db
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstrumentType>().HasData
            (
                new InstrumentType { Id = 1, Name = "Acoustic Guitar" },
                new InstrumentType { Id = 2, Name = "Electric Guitar" },
                new InstrumentType { Id = 3, Name = "Drums" },
                new InstrumentType { Id = 4, Name = "Bass" },
                new InstrumentType { Id = 5, Name = "Keyboard" }
            );
        }
    }
}
