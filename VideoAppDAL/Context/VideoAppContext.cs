using System;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Context

{



    public class VideoAppContext : DbContext
    {
        static DbContextOptions<VideoAppContext> options =
            new DbContextOptionsBuilder<VideoAppContext>().UseInMemoryDatabase("TheDB")
                                                          .Options;

        public VideoAppContext() : base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}

