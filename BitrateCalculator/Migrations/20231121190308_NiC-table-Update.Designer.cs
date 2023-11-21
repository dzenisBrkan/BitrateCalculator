﻿// <auto-generated />
using System;
using BitrateCalculator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BitrateCalculator.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231121190308_NiC-table-Update")]
    partial class NiCtableUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BitrateCalculator.Models.NIC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MAC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Rx")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TranscoderId")
                        .HasColumnType("int");

                    b.Property<long>("Tx")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TranscoderId");

                    b.ToTable("NiC");
                });

            modelBuilder.Entity("BitrateCalculator.Models.Transcoder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Device")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transcoder");
                });

            modelBuilder.Entity("BitrateCalculator.Models.NIC", b =>
                {
                    b.HasOne("BitrateCalculator.Models.Transcoder", null)
                        .WithMany("NIC")
                        .HasForeignKey("TranscoderId");
                });

            modelBuilder.Entity("BitrateCalculator.Models.Transcoder", b =>
                {
                    b.Navigation("NIC");
                });
#pragma warning restore 612, 618
        }
    }
}