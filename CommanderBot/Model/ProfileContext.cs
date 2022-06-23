using Microsoft.EntityFrameworkCore;

namespace ProfileBot.Model
{
    class ProfileContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GameProfileDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasKey(profile => profile.DiscordId);
            modelBuilder.Entity<Profile>()
                .Property(pr => pr.DiscordId)
                .ValueGeneratedNever()
                .IsRequired();
            //modelBuilder.
            //    Entity<Track>()
            //    .HasOne(track => track.Guild)
            //    .WithMany(guild => guild.Tracks)
            //    .HasForeignKey(track => track.GuildId);

            //modelBuilder
            //    .Entity<Guild>()
            //    .HasOne(guild => guild.TextChannel)
            //    .WithOne(chan => chan.Guild)
            //    .HasForeignKey<TextChannel>(chan => chan.GuildId);

            //modelBuilder.Entity<TextChannel>()
            //    .Property(chan => chan.Id)
            //    .ValueGeneratedNever();
        }
    }
}
