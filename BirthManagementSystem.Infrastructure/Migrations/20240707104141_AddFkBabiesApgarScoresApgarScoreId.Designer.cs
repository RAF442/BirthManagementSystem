﻿// <auto-generated />
using System;
using BirthManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BirthManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(BirthManagementSystemDbContext))]
    [Migration("20240707104141_AddFkBabiesApgarScoresApgarScoreId")]
    partial class AddFkBabiesApgarScoresApgarScoreId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("birth_management_system")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BirthManagementSystem.Domain.Entities.ApgarScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2(0)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ApgarScores", "birth_management_system");
                });

            modelBuilder.Entity("BirthManagementSystem.Domain.Entities.Baby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApgarScoreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalIdentityNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2(0)");

                    b.HasKey("Id");

                    b.HasIndex("ApgarScoreId");

                    b.HasIndex("PersonalIdentityNumber")
                        .IsUnique();

                    b.ToTable("Babies", "birth_management_system");
                });

            modelBuilder.Entity("BirthManagementSystem.Domain.Entities.Baby", b =>
                {
                    b.HasOne("BirthManagementSystem.Domain.Entities.ApgarScore", "ApgarScore")
                        .WithMany("Babies")
                        .HasForeignKey("ApgarScoreId");

                    b.Navigation("ApgarScore");
                });

            modelBuilder.Entity("BirthManagementSystem.Domain.Entities.ApgarScore", b =>
                {
                    b.Navigation("Babies");
                });
#pragma warning restore 612, 618
        }
    }
}
