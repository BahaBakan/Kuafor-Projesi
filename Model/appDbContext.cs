using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class AppDbContext : DbContext
    { 
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Calisan> Calisanlar  => Set<Calisan>();
        public DbSet<Islem> Islemler  => Set<Islem>();
        public DbSet<CalisanIslem> CalisanIslemler  => Set<CalisanIslem>();
        public DbSet<Musteri> Musteriler  => Set<Musteri>();
        public DbSet<Randevu> Randevular  => Set<Randevu>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Çalışan-İşlem Ara Tablosu İlişkisi
            modelBuilder.Entity<CalisanIslem>()
                .HasKey(ci => new { ci.CalisanId, ci.IslemId });

            modelBuilder.Entity<CalisanIslem>()
                .HasOne(ci => ci.Calisan)
                .WithMany(c => c.CalisanIslemler)
                .HasForeignKey(ci => ci.CalisanId);

            modelBuilder.Entity<CalisanIslem>()
                .HasOne(ci => ci.Islem)
                .WithMany(i => i.CalisanIslemler)
                .HasForeignKey(ci => ci.IslemId);
        }
    }
}
