﻿// <auto-generated />
using DemoCRUD.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoCRUD.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoCRUD.Model.Models.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderID"));

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderID");

                    b.ToTable("tblGender");
                });

            modelBuilder.Entity("DemoCRUD.Model.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateID"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateID");

                    b.ToTable("tblState");
                });

            modelBuilder.Entity("DemoCRUD.Model.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("StateId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DemoCRUD.Model.Models.Students", b =>
                {
                    b.HasOne("DemoCRUD.Model.Models.Gender", "Gender")
                        .WithMany("Students")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoCRUD.Model.Models.State", "State")
                        .WithMany("Students")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("State");
                });

            modelBuilder.Entity("DemoCRUD.Model.Models.Gender", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("DemoCRUD.Model.Models.State", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
