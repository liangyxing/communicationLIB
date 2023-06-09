﻿// <auto-generated />
using ConfigDB.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConfigDB.Migrations
{
    [DbContext(typeof(SqlLiteDBContext))]
    partial class SqlLiteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ConfigDB.Entity.DANodeInfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MachineName")
                        .HasColumnType("longtext");

                    b.Property<string>("Tag_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Time")
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DANodeInfo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
