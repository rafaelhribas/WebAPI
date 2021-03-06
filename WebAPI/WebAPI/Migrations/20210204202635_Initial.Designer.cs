﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(ContaContext))]
    [Migration("20210204202635_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("WebAPI.Models.Conta", b =>
                {
                    b.Property<int>("ContaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiasAtraso")
                        .HasColumnType("int");

                    b.Property<decimal>("JurosDia")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Multa")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorFinal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("ValorOriginal")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ContaId");

                    b.ToTable("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}
