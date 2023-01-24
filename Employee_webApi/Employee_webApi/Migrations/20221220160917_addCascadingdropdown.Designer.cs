﻿// <auto-generated />
using Employee_webApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee_webApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221220160917_addCascadingdropdown")]
    partial class addCascadingdropdown
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employee_webApi.Models.CountryMst", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("countryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CountryMst");
                });

            modelBuilder.Entity("Employee_webApi.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Employee_webApi.Models.StateMst", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryMstid")
                        .HasColumnType("int");

                    b.Property<int>("stateName")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CountryMstid");

                    b.ToTable("StateMst");
                });

            modelBuilder.Entity("Employee_webApi.Models.StateMst", b =>
                {
                    b.HasOne("Employee_webApi.Models.CountryMst", "CountryMst")
                        .WithMany()
                        .HasForeignKey("CountryMstid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryMst");
                });
#pragma warning restore 612, 618
        }
    }
}
