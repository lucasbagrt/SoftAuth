using Microsoft.EntityFrameworkCore;

namespace SoftAuth.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UsersLogs { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuGroup> MenuGroup { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }        
    }
}
