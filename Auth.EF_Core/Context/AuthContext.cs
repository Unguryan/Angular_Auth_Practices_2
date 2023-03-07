using Auth.EF_Core.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Auth.EF_Core.Context
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }

        public DbSet<UserDbo> Users { get; set; }
        public DbSet<TokenDbo> Tokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AuthUsers.db");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDbo>().ToTable("Users");
            modelBuilder.Entity<TokenDbo>().ToTable("Tokens");

            modelBuilder.Entity<TokenDbo>()
                        .HasOne(x => x.User)
                        .WithOne()
                        .HasForeignKey<TokenDbo>(x => x.UserId);
        }
    }
}
