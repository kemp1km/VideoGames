// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGames.Data;

namespace VideoGames.Migrations
{
    [DbContext(typeof(VideoGamesContext))]
    [Migration("20210413154605_GamesFix2")]
    partial class GamesFix2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VideoGames.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GenreId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.HasIndex("GenreId1");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("VideoGames.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.HasKey("GenreId");

                    b.HasIndex("GameId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("VideoGames.Models.MyGames", b =>
                {
                    b.Property<int>("MyGamesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReviewGrade")
                        .HasColumnType("int");

                    b.HasKey("MyGamesId");

                    b.HasIndex("GameID");

                    b.ToTable("MyGames");
                });

            modelBuilder.Entity("VideoGames.Models.Game", b =>
                {
                    b.HasOne("VideoGames.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId1");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("VideoGames.Models.Genre", b =>
                {
                    b.HasOne("VideoGames.Models.Game", null)
                        .WithMany("GenreId")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("VideoGames.Models.MyGames", b =>
                {
                    b.HasOne("VideoGames.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("VideoGames.Models.Game", b =>
                {
                    b.Navigation("GenreId");
                });
#pragma warning restore 612, 618
        }
    }
}
