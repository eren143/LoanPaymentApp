﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AraOdemeContext))]
    partial class AraOdemeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("OdemePlani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OdemeSayisi")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AraOdemePlanlari");
                });

            modelBuilder.Entity("OdemeSatiri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Anapara")
                        .HasColumnType("REAL");

                    b.Property<double>("Faiz")
                        .HasColumnType("REAL");

                    b.Property<double>("KalanTutar")
                        .HasColumnType("REAL");

                    b.Property<int>("OdemePlaniId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Taksit")
                        .HasColumnType("REAL");

                    b.Property<int>("TaksitNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OdemePlaniId");

                    b.ToTable("OdemeSatirlari");
                });

            modelBuilder.Entity("OdemeSatiri", b =>
                {
                    b.HasOne("OdemePlani", "OdemePlani")
                        .WithMany("Satirlar")
                        .HasForeignKey("OdemePlaniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OdemePlani");
                });

            modelBuilder.Entity("OdemePlani", b =>
                {
                    b.Navigation("Satirlar");
                });
#pragma warning restore 612, 618
        }
    }
}
