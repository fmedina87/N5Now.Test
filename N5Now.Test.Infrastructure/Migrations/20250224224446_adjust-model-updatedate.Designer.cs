﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N5Now.Test.Infrastructure.Data;

#nullable disable

namespace N5Now.Test.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250224224446_adjust-model-updatedate")]
    partial class adjustmodelupdatedate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("N5Now.Test.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstLastName")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("SecondLastName")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("SecondName")
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("N5Now.Test.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PermissionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PermissionTypeId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("N5Now.Test.Domain.Entities.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PermissionTypes");
                });

            modelBuilder.Entity("N5Now.Test.Domain.Entities.Permission", b =>
                {
                    b.HasOne("N5Now.Test.Domain.Entities.Employee", "Employee")
                        .WithMany("Permissions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("N5Now.Test.Domain.Entities.PermissionType", "PermissionType")
                        .WithMany("Permissions")
                        .HasForeignKey("PermissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("PermissionType");
                });

            modelBuilder.Entity("N5Now.Test.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("N5Now.Test.Domain.Entities.PermissionType", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
