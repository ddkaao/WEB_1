﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoRep1.Migrations
{
    [DbContext(typeof(EducationContext))]
    partial class EducationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutoRep.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_clients");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_clients_order_id");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("AutoRep.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientID")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<int>("ServiceID")
                        .HasColumnType("integer")
                        .HasColumnName("service_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("AutoRep.Data.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NameOfService")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name_of_service");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.Property<int?>("Time")
                        .HasColumnType("integer")
                        .HasColumnName("time");

                    b.HasKey("Id")
                        .HasName("pk_services");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_services_order_id");

                    b.ToTable("services", (string)null);
                });

            modelBuilder.Entity("AutoRep.Data.Models.Client", b =>
                {
                    b.HasOne("AutoRep.Data.Models.Order", null)
                        .WithMany("Clients")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_clients_orders_order_id");
                });

            modelBuilder.Entity("AutoRep.Data.Models.Service", b =>
                {
                    b.HasOne("AutoRep.Data.Models.Order", null)
                        .WithMany("Services")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_services_orders_order_id");
                });

            modelBuilder.Entity("AutoRep.Data.Models.Order", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}