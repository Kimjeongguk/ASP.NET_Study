﻿// <auto-generated />
using AspnetNote.MVC6.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspnetNote.MVC6.Migrations
{
    [DbContext(typeof(AspnetDBContext))]
    partial class AspnetDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AspnetNote.MVC6.Models.Note", b =>
                {
                    b.Property<int>("NoteNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NoteContents")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NoteTitle")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserNo")
                        .HasColumnType("int");

                    b.HasKey("NoteNo");

                    b.HasIndex("UserNo");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("AspnetNote.MVC6.Models.User", b =>
                {
                    b.Property<int>("UserNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserNo");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AspnetNote.MVC6.Models.Note", b =>
                {
                    b.HasOne("AspnetNote.MVC6.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
