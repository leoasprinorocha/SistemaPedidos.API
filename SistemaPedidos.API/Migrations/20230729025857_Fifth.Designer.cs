﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaPedidos.Orm.Core;

#nullable disable

namespace SistemaPedidos.API.Migrations
{
    [DbContext(typeof(SistemaPedidosContext))]
    [Migration("20230729025857_Fifth")]
    partial class Fifth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaPedidos.Domain.Entities.AdesaoEmpresa.Adesao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Adesao");
                });

            modelBuilder.Entity("SistemaPedidos.Domain.Entities.Sistema.Modulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("SistemaPedidos.Domain.Entities.Sistema.Rotina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ModuloId")
                        .HasColumnType("char(36)");

                    b.Property<string>("RotaUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.ToTable("Rotina");
                });

            modelBuilder.Entity("SistemaPedidos.Domain.Entities.Usuario.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AdesaoUsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("IdAdesao")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdAspnetUser")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AdesaoUsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SistemaPedidos.Domain.Entities.Sistema.Rotina", b =>
                {
                    b.HasOne("SistemaPedidos.Domain.Entities.Sistema.Modulo", "Modulo")
                        .WithMany("Rotinas")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("SistemaPedidos.Domain.Entities.Usuario.Usuario", b =>
                {
                    b.HasOne("SistemaPedidos.Domain.Entities.AdesaoEmpresa.Adesao", "AdesaoUsuario")
                        .WithMany()
                        .HasForeignKey("AdesaoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdesaoUsuario");
                });

            modelBuilder.Entity("SistemaPedidos.Domain.Entities.Sistema.Modulo", b =>
                {
                    b.Navigation("Rotinas");
                });
#pragma warning restore 612, 618
        }
    }
}
