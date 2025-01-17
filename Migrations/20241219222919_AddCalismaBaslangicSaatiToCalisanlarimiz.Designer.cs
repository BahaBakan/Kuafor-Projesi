﻿// <auto-generated />
using System;
using KuaforProjesi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KuaforProjesi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241219222919_AddCalismaBaslangicSaatiToCalisanlarimiz")]
    partial class AddCalismaBaslangicSaatiToCalisanlarimiz
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("KuaforProjesi.Data.CalisanSaat", b =>
                {
                    b.Property<int>("CalisanSaatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CalisanId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CalisanlarimizCalisanId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Saat")
                        .HasColumnType("TEXT");

                    b.HasKey("CalisanSaatId");

                    b.HasIndex("CalisanlarimizCalisanId");

                    b.ToTable("CalisanSaatler");
                });

            modelBuilder.Entity("KuaforProjesi.Data.Calisanlarimiz", b =>
                {
                    b.Property<int>("CalisanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CalismaBaslangicSaati")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CalismaBitisSaati")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UzmanlikAlani")
                        .HasColumnType("TEXT");

                    b.HasKey("CalisanId");

                    b.ToTable("Calisanlarimiz");
                });

            modelBuilder.Entity("KuaforProjesi.Data.Islem", b =>
                {
                    b.Property<int>("IslemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CalisanId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IslemAdi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IslemSuresi")
                        .HasColumnType("INTEGER");

                    b.HasKey("IslemId");

                    b.HasIndex("CalisanId");

                    b.ToTable("Islemler");
                });

            modelBuilder.Entity("KuaforProjesi.Data.Randevu", b =>
                {
                    b.Property<int>("RandevuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CalisanId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IslemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MusteriAdi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Saat")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("TEXT");

                    b.HasKey("RandevuId");

                    b.HasIndex("CalisanId");

                    b.HasIndex("IslemId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("KuaforProjesi.Data.Register", b =>
                {
                    b.Property<int>("RegisterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sifre")
                        .HasColumnType("TEXT");

                    b.HasKey("RegisterId");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("KuaforProjesi.Data.CalisanSaat", b =>
                {
                    b.HasOne("KuaforProjesi.Data.Calisanlarimiz", "Calisanlarimiz")
                        .WithMany()
                        .HasForeignKey("CalisanlarimizCalisanId");

                    b.Navigation("Calisanlarimiz");
                });

            modelBuilder.Entity("KuaforProjesi.Data.Islem", b =>
                {
                    b.HasOne("KuaforProjesi.Data.Calisanlarimiz", "Calisan")
                        .WithMany("Islemler")
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");
                });

            modelBuilder.Entity("KuaforProjesi.Data.Randevu", b =>
                {
                    b.HasOne("KuaforProjesi.Data.Calisanlarimiz", "Calisan")
                        .WithMany()
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KuaforProjesi.Data.Islem", "Islem")
                        .WithMany()
                        .HasForeignKey("IslemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");

                    b.Navigation("Islem");
                });

            modelBuilder.Entity("KuaforProjesi.Data.Calisanlarimiz", b =>
                {
                    b.Navigation("Islemler");
                });
#pragma warning restore 612, 618
        }
    }
}
