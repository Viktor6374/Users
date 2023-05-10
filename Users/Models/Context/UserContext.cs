
using Microsoft.EntityFrameworkCore;
using Users.Models.Entities;

namespace Users.Models.Context
{
    public class UserContext : DbContext
    {
        public UserContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; private set; }
        public DbSet<UserState> UserStates { get; private set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=Users;Username=postgres;Password=123456");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup[]
                {
                    new UserGroup(1, Enums.Group.User, ""),
                    new UserGroup(2, Enums.Group.Admin, "")
                });
            modelBuilder.Entity<UserState>().HasData(
                new UserState[]
                {
                    new UserState(1, Enums.State.Active, ""),
                    new UserState(2, Enums.State.Blocked, "")
                });
        }
    }
}
