﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241113192322_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Countries.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_countries");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("Domain.Faculties.GameImage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid")
                        .HasColumnName("game_id");

                    b.HasKey("Id")
                        .HasName("pk_game_image");

                    b.HasIndex("GameId")
                        .HasDatabaseName("ix_game_image_game_id");

                    b.ToTable("game_image", (string)null);
                });

            modelBuilder.Entity("Domain.Game.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_games");

                    b.ToTable("games", (string)null);
                });

            modelBuilder.Entity("Domain.Matches.MatchGame", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid")
                        .HasColumnName("game_id");

                    b.Property<int>("MaxTeams")
                        .HasColumnType("integer")
                        .HasColumnName("max_teams");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_at");

                    b.Property<string>("Winner")
                        .HasColumnType("text")
                        .HasColumnName("winner");

                    b.HasKey("Id")
                        .HasName("pk_matches");

                    b.HasIndex("GameId")
                        .HasDatabaseName("ix_matches_game_id");

                    b.ToTable("matches", (string)null);
                });

            modelBuilder.Entity("Domain.Players.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid")
                        .HasColumnName("country_id");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid")
                        .HasColumnName("game_id");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nick_name");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea")
                        .HasColumnName("photo");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid")
                        .HasColumnName("team_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.HasKey("Id")
                        .HasName("pk_players");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("ix_players_country_id");

                    b.HasIndex("GameId")
                        .HasDatabaseName("ix_players_game_id");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_players_team_id");

                    b.ToTable("players", (string)null);
                });

            modelBuilder.Entity("Domain.TeamMatches.TeamMatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsWinner")
                        .HasColumnType("boolean")
                        .HasColumnName("is_winner");

                    b.Property<Guid>("MatchId")
                        .HasColumnType("uuid")
                        .HasColumnName("match_id");

                    b.Property<int>("Score")
                        .HasColumnType("integer")
                        .HasColumnName("score");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid")
                        .HasColumnName("team_id");

                    b.HasKey("Id")
                        .HasName("pk_team_matches");

                    b.HasIndex("MatchId")
                        .HasDatabaseName("ix_team_matches_match_id");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_team_matches_team_id");

                    b.ToTable("team_matches", (string)null);
                });

            modelBuilder.Entity("Domain.Teams.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<byte[]>("Icon")
                        .HasColumnType("bytea")
                        .HasColumnName("icon");

                    b.Property<int>("MatchCount")
                        .HasColumnType("integer")
                        .HasColumnName("match_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(225)")
                        .HasColumnName("name");

                    b.Property<int>("WinCount")
                        .HasColumnType("integer")
                        .HasColumnName("win_count");

                    b.Property<double>("WinRate")
                        .HasColumnType("double precision")
                        .HasColumnName("win_rate");

                    b.HasKey("Id")
                        .HasName("pk_teams");

                    b.ToTable("teams", (string)null);
                });

            modelBuilder.Entity("Domain.Faculties.GameImage", b =>
                {
                    b.HasOne("Domain.Game.Game", "Game")
                        .WithMany("Images")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_game_images_games_id");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Domain.Matches.MatchGame", b =>
                {
                    b.HasOne("Domain.Game.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Player_Game");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Domain.Players.Player", b =>
                {
                    b.HasOne("Domain.Countries.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Player_Country");

                    b.HasOne("Domain.Game.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Player_Game");

                    b.HasOne("Domain.Teams.Team", "Team")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Player_Team");

                    b.Navigation("Country");

                    b.Navigation("Game");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Domain.TeamMatches.TeamMatch", b =>
                {
                    b.HasOne("Domain.Matches.MatchGame", "MatchGame")
                        .WithMany("TeamMatches")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_team_matches_matches_match_id");

                    b.HasOne("Domain.Teams.Team", "Team")
                        .WithMany("TeamMatches")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_team_matches_teams_team_id");

                    b.Navigation("MatchGame");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Domain.Game.Game", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Domain.Matches.MatchGame", b =>
                {
                    b.Navigation("TeamMatches");
                });

            modelBuilder.Entity("Domain.Teams.Team", b =>
                {
                    b.Navigation("PlayerTeams");

                    b.Navigation("TeamMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
