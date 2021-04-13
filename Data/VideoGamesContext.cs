using Microsoft.EntityFrameworkCore;
using VideoGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGames.Data
{
    public class VideoGamesContext :DbContext
    {
        public VideoGamesContext(DbContextOptions<VideoGamesContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MyGames> MyGames { get; set; }
    }
}
