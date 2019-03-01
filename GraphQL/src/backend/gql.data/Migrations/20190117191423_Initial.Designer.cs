﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gql.data;

namespace gql.data.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20190117191423_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("gql.core.model.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("gql.core.model.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeveloperId");

                    b.Property<string>("Name");

                    b.Property<int?>("PublisherId");

                    b.Property<DateTime>("RelaseDate");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("gql.core.model.Game", b =>
                {
                    b.HasOne("gql.core.model.Company", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId");

                    b.HasOne("gql.core.model.Company", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");
                });
#pragma warning restore 612, 618
        }
    }
}