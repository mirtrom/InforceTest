using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InforceData.Models;

namespace InforceData.Data {
    public class InforceDbContext : IdentityDbContext<IdentityUser>{
        public InforceDbContext(DbContextOptions<InforceDbContext> options) : base(options) {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Reaction> Reactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            var readerRoleId = "88eb2aab-6e85-4580-88bf-240c6a7deaec";
            var adminRoleId = "9122bc77-d23e-4460-ba28-d8f93f011049";
            var roles = new List<IdentityRole> {
                new() { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = adminRoleId },
                new() { Id = readerRoleId, Name = "User", NormalizedName = "USER", ConcurrencyStamp = readerRoleId },
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var adminUserId = "167be992-9f8d-4a35-a24a-6f95b008cb85";
            var admin = new IdentityUser {
                Id = adminUserId,
                UserName = "admin@example.com",
                NormalizedUserName = "admin@example.com".ToUpper(),
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com".ToUpper(),
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);

            var adminRole = new List<IdentityUserRole<string>> {
                new() {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                },
                new() {
                    RoleId = readerRoleId,
                    UserId = adminUserId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRole);
        }
    }
}
