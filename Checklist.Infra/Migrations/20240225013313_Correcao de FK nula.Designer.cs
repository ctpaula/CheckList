﻿// <auto-generated />
using System;
using Checklist.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Checklist.Infra.Migrations
{
    [DbContext(typeof(RDbContext))]
    [Migration("20240225013313_Correcao de FK nula")]
    partial class CorrecaodeFKnula
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CheckList.Domain.CheckListBody", b =>
                {
                    b.Property<int>("CheckListBodyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CheckListBodyId"));

                    b.Property<DateTime?>("DataFimExecucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicioExecucao")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("CheckListBodyId");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("CheckListBody");
                });

            modelBuilder.Entity("CheckList.Domain.CheckListItem", b =>
                {
                    b.Property<int>("CheckListItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CheckListItemId"));

                    b.Property<int>("CheckListBodyId")
                        .HasColumnType("int");

                    b.Property<bool>("EstaChecado")
                        .HasColumnType("bit");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PassouCheck")
                        .HasColumnType("bit");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("int");

                    b.HasKey("CheckListItemId");

                    b.HasIndex("CheckListBodyId");

                    b.HasIndex("PerguntaId");

                    b.ToTable("CheckListItem");
                });

            modelBuilder.Entity("CheckList.Domain.Pergunta", b =>
                {
                    b.Property<int>("PerguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PerguntaId"));

                    b.Property<string>("Parametro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PerguntaId");

                    b.ToTable("Pergunta");
                });

            modelBuilder.Entity("CheckList.Domain.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SupervisorCheckList")
                        .HasColumnType("bit");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CheckList.Domain.CheckListBody", b =>
                {
                    b.HasOne("CheckList.Domain.Usuario", "Executor")
                        .WithMany("CheckListsExecutor")
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheckList.Domain.Usuario", "Supervisor")
                        .WithMany("CheckListsSupervisor")
                        .HasForeignKey("SupervisorId");

                    b.Navigation("Executor");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("CheckList.Domain.CheckListItem", b =>
                {
                    b.HasOne("CheckList.Domain.CheckListBody", "CheckListBody")
                        .WithMany("CheckListItems")
                        .HasForeignKey("CheckListBodyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheckList.Domain.Pergunta", "Pergunta")
                        .WithMany()
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CheckListBody");

                    b.Navigation("Pergunta");
                });

            modelBuilder.Entity("CheckList.Domain.CheckListBody", b =>
                {
                    b.Navigation("CheckListItems");
                });

            modelBuilder.Entity("CheckList.Domain.Usuario", b =>
                {
                    b.Navigation("CheckListsExecutor");

                    b.Navigation("CheckListsSupervisor");
                });
#pragma warning restore 612, 618
        }
    }
}
