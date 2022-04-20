using CommanderBot.Model;
using Microsoft.EntityFrameworkCore;

namespace CommanderBot
{
    class ModelContext : DbContext
    {
        public DbSet<Vassal> Vassals { get; set; }
        public DbSet<Suzerain> Suzerains { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=WargameDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vassal>()
                .Property(prop => prop.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Suzerain>()
                .Property(prop => prop.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Vassal>()
                .HasOne(vassal => vassal.Suzerain)
                .WithMany(suzerain => suzerain.Vassals)
                .HasForeignKey(vassal => vassal.SuzerainId);
        }
    }
}
