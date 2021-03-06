﻿// <auto-generated />
using System;
using Learning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Learning.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200208144217_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Learning.Threads.BusinessRules.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creative_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distributor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("IMDB_Rating")
                        .HasColumnType("real");

                    b.Property<int?>("IMDB_Votes")
                        .HasColumnType("int");

                    b.Property<string>("MPAA_Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Major_Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Production_Budget")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Release_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rotten_Tomatoes_Rating")
                        .HasColumnType("int");

                    b.Property<long?>("Running_Time_min")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("US_DVD_Sales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("US_Gross")
                        .HasColumnType("bigint");

                    b.Property<long?>("Worldwide_Gross")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
