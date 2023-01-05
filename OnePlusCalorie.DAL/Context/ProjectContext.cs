using Microsoft.EntityFrameworkCore;
using OnePlusCalorie.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePlusCalorie.DAL.Context
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =.; Database = OnePlusCalorieeDb; integrated security = true;");
        }


        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Admin> Adminler { get; set; }
        public DbSet<ProfilBilgisi> ProfilBilgileri { get; set; }

        public DbSet<Besin> Besinler { get; set; }
        public DbSet<Kategori> Kategorilerler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Kullanici>().HasOne(x => x.ProfilBilgisi).WithOne(x => x.Kullanici).HasForeignKey("ProfilBilgisi");

            modelBuilder.Entity<ProfilBilgisi>().HasOne(p => p.Kullanici).WithOne(p => p.ProfilBilgisi).HasForeignKey<ProfilBilgisi>(p => p.KullaniciID);

            modelBuilder.Entity<Besin>().HasOne(besin => besin.Kategori).WithMany(Kategori => Kategori.KategorininBesinleri).HasForeignKey(fk => fk.KategoriID);

            //modelBuilder.Entity<Besin>().HasOne(besin => besin.Admin).WithMany(admin => admin.AdmininGirdiğiBesinler).HasForeignKey(fk => fk.AdminID).OnDelete(DeleteBehavior.ClientSetNull);

            //modelBuilder.Entity<Kategori>().HasOne(kategori => kategori.Admin).WithMany(admin => admin.AdmininGirdiğiKategoriler).HasForeignKey(fk => fk.AdminID).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Besin>().HasOne(besin => besin.Kullanici).WithMany(kullanici => kullanici.KullanicininGirdiğiBesinler).HasForeignKey(fk => fk.KullaniciID).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Kategori>().HasOne(kategori => kategori.Kullanici).WithMany(kullanici => kullanici.KullanicininGirdiğiKategoriler).HasForeignKey(fk => fk.KullaniciID).OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }





    }
}
