﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workload.Data;

namespace Workload.Data.Migrations
{
    [DbContext(typeof(CourcesDbContext))]
    partial class CourcesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Workload.Business.Entities.Cource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cource");
                });

            modelBuilder.Entity("Workload.Business.Entities.WorkLoadHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("WorkLoad")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("WorkLoadHistory");
                });

            modelBuilder.Entity("Workload.Business.Entities.WorkLoadHistoryCource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourceId")
                        .HasColumnType("int");

                    b.Property<int>("WorkLoadHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourceId");

                    b.HasIndex("WorkLoadHistoryId");

                    b.ToTable("WorkLoadHistoryCources");
                });

            modelBuilder.Entity("Workload.Business.Entities.WorkLoadHistoryCource", b =>
                {
                    b.HasOne("Workload.Business.Entities.Cource", "Cource")
                        .WithMany()
                        .HasForeignKey("CourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workload.Business.Entities.WorkLoadHistory", "WorkLoadHistory")
                        .WithMany("Cources")
                        .HasForeignKey("WorkLoadHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cource");

                    b.Navigation("WorkLoadHistory");
                });

            modelBuilder.Entity("Workload.Business.Entities.WorkLoadHistory", b =>
                {
                    b.Navigation("Cources");
                });
#pragma warning restore 612, 618
        }
    }
}
