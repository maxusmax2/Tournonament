﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Tournonamemt.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231212174524_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("MatchUser", b =>
                {
                    b.Property<int>("MatchesId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsId")
                        .HasColumnType("int");

                    b.HasKey("MatchesId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("MatchUser");
                });

            modelBuilder.Entity("TournamentUser", b =>
                {
                    b.Property<int>("ParticipantsId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantsId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("TournamentUser");
                });

            modelBuilder.Entity("Tournonamemt.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("disciplines");
                });

            modelBuilder.Entity("Tournonamemt.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GroupNumber")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantNumber")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("Tournonamemt.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsGroupStep")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TourId");

                    b.HasIndex("TournamentId");

                    b.ToTable("matches");
                });

            modelBuilder.Entity("Tournonamemt.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("scores");
                });

            modelBuilder.Entity("Tournonamemt.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MatchNumber")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsNumber")
                        .HasColumnType("int");

                    b.Property<int>("TourNumber")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("tours");
                });

            modelBuilder.Entity("Tournonamemt.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<int?>("GroupNumber")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParticipantNumber")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantNumberMax")
                        .HasColumnType("int");

                    b.Property<decimal>("PrizeFund")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TourNumber")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.Property<bool>("WithGroupStep")
                        .HasColumnType("bit");

                    b.Property<int?>("numberLeavingTheGroup")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("WinnerId");

                    b.ToTable("tournaments");
                });

            modelBuilder.Entity("Tournonamemt.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AboutMe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TourUser", b =>
                {
                    b.Property<int>("ParticipantsId")
                        .HasColumnType("int");

                    b.Property<int>("ToursId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantsId", "ToursId");

                    b.HasIndex("ToursId");

                    b.ToTable("TourUser");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("Tournonamemt.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tournonamemt.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MatchUser", b =>
                {
                    b.HasOne("Tournonamemt.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("MatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tournonamemt.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TournamentUser", b =>
                {
                    b.HasOne("Tournonamemt.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tournonamemt.Models.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tournonamemt.Models.Group", b =>
                {
                    b.HasOne("Tournonamemt.Models.Tournament", "Tournament")
                        .WithMany("Groups")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Tournonamemt.Models.Match", b =>
                {
                    b.HasOne("Tournonamemt.Models.Group", null)
                        .WithMany("Matchs")
                        .HasForeignKey("GroupId");

                    b.HasOne("Tournonamemt.Models.Tour", "Tour")
                        .WithMany("Matches")
                        .HasForeignKey("TourId");

                    b.HasOne("Tournonamemt.Models.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Tournonamemt.Models.Score", b =>
                {
                    b.HasOne("Tournonamemt.Models.Match", null)
                        .WithMany("Scores")
                        .HasForeignKey("MatchId");

                    b.HasOne("Tournonamemt.Models.User", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Tournonamemt.Models.Tour", b =>
                {
                    b.HasOne("Tournonamemt.Models.Tournament", "Tournament")
                        .WithMany("Tours")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Tournonamemt.Models.Tournament", b =>
                {
                    b.HasOne("Tournonamemt.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tournonamemt.Models.User", "Winner")
                        .WithMany("WinTournaments")
                        .HasForeignKey("WinnerId");

                    b.Navigation("Discipline");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("TourUser", b =>
                {
                    b.HasOne("Tournonamemt.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tournonamemt.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("ToursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tournonamemt.Models.Group", b =>
                {
                    b.Navigation("Matchs");
                });

            modelBuilder.Entity("Tournonamemt.Models.Match", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("Tournonamemt.Models.Tour", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Tournonamemt.Models.Tournament", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Tours");
                });

            modelBuilder.Entity("Tournonamemt.Models.User", b =>
                {
                    b.Navigation("WinTournaments");
                });
#pragma warning restore 612, 618
        }
    }
}