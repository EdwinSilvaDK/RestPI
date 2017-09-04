using System;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Context

{



    public class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;

        public InMemoryContext() : base(options)
        {

        }

        public DbSet<Video> Videos
        {
            get;
            set;
        }
    }
}

