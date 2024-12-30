
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deneme4;

namespace deneme4
{
    internal class DBContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        public DbSet<Sinif> tblSiniflar { get; set; }

        public DbSet<OgrenciDers> tblOgrenciDers { get; set; }

        public DbSet<Dersler> tblDersler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //Database bağlantım
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer($"Data Source=.;Initial Catalog=Proje;Integrated Security=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ogrenci ile Sinif arasında ilişki
            modelBuilder.Entity<Ogrenci>()
                .HasOne(o => o.Sinif)  //has one 1  -- with many çok  bire çok ilişki
                .WithMany(s => s.Ogrenciler)
                .HasForeignKey(o => o.SinifId);  // SinifId foreign key

            // Ogrenci ve Dersler arasında many-to-many ilişkiyi kuran bağlantı tablosu
            modelBuilder.Entity<OgrenciDers>()
                .HasKey(od => new { od.OgrenciId, od.DersId });  // composite key (birincil anahtar değil, ancak bu iki alanla ilişkiyi belirliyoruz)

            modelBuilder.Entity<OgrenciDers>()
                .HasOne(od => od.Ogrenci)
                .WithMany(o => o.OgrenciDersler)
                .HasForeignKey(od => od.OgrenciId);  // OgrenciId foreign key

            modelBuilder.Entity<OgrenciDers>()
                .HasOne(od => od.Dersler)
                .WithMany(d => d.OgrenciDersler)
                .HasForeignKey(od => od.DersId);  // DersId foreign key

            // Dersler ile OgrenciDers ilişkisini tanımladım
            modelBuilder.Entity<Dersler>()
                .HasMany(d => d.OgrenciDersler) // çoka bir ilişki
                .WithOne(od => od.Dersler)
                .HasForeignKey(od => od.DersId);

            // OgrenciDers ile Ogrenci ilişkisini tanımladım
            modelBuilder.Entity<Ogrenci>()
                .HasMany(o => o.OgrenciDersler)
                .WithOne(od => od.Ogrenci)
                .HasForeignKey(od => od.OgrenciId);
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar")
                .HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).HasColumnType("varchar")
                .HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Ogrenci>().HasIndex(o => o.Numara).IsUnique();
            modelBuilder.Entity<Ogrenci>().Property(o => o.SinifId).HasColumnType("int")
                .HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Sinif>().Property(o => o.SinifAd).HasColumnType("varchar")
                .HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Sinif>().HasIndex(o => o.SinifAd).IsUnique();
            modelBuilder.Entity<Sinif>().Property(o => o.Kontenjan).HasColumnType("int")
                .HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Dersler>().HasKey(d => d.DersId);
            modelBuilder.Entity<Dersler>().Property(o => o.DersKod).HasColumnType("varchar")
                .HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Dersler>().HasIndex(o => o.DersKod).IsUnique();
            modelBuilder.Entity<Dersler>().Property(o => o.DersAd).HasColumnType("varchar")
                .HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Dersler>().HasIndex(o => o.DersAd).IsUnique();
            modelBuilder.Entity<OgrenciDers>().Property(o => o.DersId).HasColumnType("int")
                .HasMaxLength(20).IsRequired();
            modelBuilder.Entity<OgrenciDers>().Property(o => o.OgrenciId).HasColumnType("int")
                .HasMaxLength(20).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
