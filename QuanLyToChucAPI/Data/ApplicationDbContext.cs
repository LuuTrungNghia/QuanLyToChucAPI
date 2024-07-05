using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyToChuc.API.Models;
using QuanLyToChucAPI.Models;

namespace QuanLyToChucAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<SystemUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToChuc> ToChucs { get; set; }
        public DbSet<NguoiLienHe> NguoiLienHes { get; set; }
        public DbSet<PhuongThucLienLac> PhuongThucLienLacs { get; set; }
        public DbSet<ThongTinDinhDanh> ThongTinDinhDanhs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.Property(u => u.FullName).IsRequired();
                entity.Property(e => e.Address);
            });

            modelBuilder.Entity<ToChuc>()
               .HasMany(t => t.NguoiLienHes)
               .WithOne(n => n.ToChuc)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NguoiLienHe>()
                .HasOne(n => n.ToChuc)
                .WithMany(n => n.NguoiLienHes)
                .HasForeignKey(n => n.ToChucID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}