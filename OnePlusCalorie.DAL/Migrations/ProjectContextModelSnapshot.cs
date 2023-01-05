﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnePlusCalorie.DAL.Context;

#nullable disable

namespace OnePlusCalorie.DAL.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AdminAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminSifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.Besin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BesinAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kalori")
                        .HasColumnType("int");

                    b.Property<double>("KarbonHidrat")
                        .HasColumnType("float");

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.Property<double>("Porsiyon")
                        .HasColumnType("float");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.Property<double>("Yag")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("KategoriID");

                    b.HasIndex("KullaniciID");

                    b.ToTable("Besinler");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.Kategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("KategoriAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KategoriDetay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KullaniciID");

                    b.ToTable("Kategorilerler");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.Kullanici", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GuncellemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UyelikTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.ProfilBilgisi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Boy")
                        .HasColumnType("float");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<DateTime>("GuncellemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<double>("Kilo")
                        .HasColumnType("float");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("VucutKitleEndeksi")
                        .HasColumnType("float");

                    b.Property<int>("Yas")
                        .HasColumnType("int");

                    b.Property<string>("YasamTarzi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KullaniciID")
                        .IsUnique();

                    b.ToTable("ProfilBilgileri");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.Besin", b =>
                {
                    b.HasOne("OnePlusCalorie.DATA.Entities.Kategori", "Kategori")
                        .WithMany("KategorininBesinleri")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePlusCalorie.DATA.Entities.Kullanici", "Kullanici")
                        .WithMany("KullanicininGirdiğiBesinler")
                        .HasForeignKey("KullaniciID")
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.Kategori", b =>
                {
                    b.HasOne("OnePlusCalorie.DATA.Entities.Kullanici", "Kullanici")
                        .WithMany("KullanicininGirdiğiKategoriler")
                        .HasForeignKey("KullaniciID")
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.ProfilBilgisi", b =>
                {
                    b.HasOne("OnePlusCalorie.DATA.Entities.Kullanici", "Kullanici")
                        .WithOne("ProfilBilgisi")
                        .HasForeignKey("OnePlusCalorie.DATA.Entities.ProfilBilgisi", "KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.Kategori", b =>
                {
                    b.Navigation("KategorininBesinleri");
                });

            modelBuilder.Entity("OnePlusCalorie.DATA.Entities.Kullanici", b =>
                {
                    b.Navigation("KullanicininGirdiğiBesinler");

                    b.Navigation("KullanicininGirdiğiKategoriler");

                    b.Navigation("ProfilBilgisi")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}