using System;
using System.Collections.Generic;
using VideoAppDAL.Entities;
using VideoAppDAL.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VideoAppDAL.Repository
{
    public class GenreRepository : IGenreRepository
    {
        VideoAppContext _context;
        public GenreRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Genre Create(Genre gen)
        {
            if (gen.Video != null)
            {
                _context.Entry(gen.Video).State =
                    EntityState.Unchanged;
            }
            _context.Genres.Add(gen);
            return gen;
        }

        public Genre Delete(int Id)
        {
            var gen = Get(Id);
            _context.Genres.Remove(gen);
            return gen;
        }

        public Genre Get(int Id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == Id);

        }

        public List<Genre> GetAll()
        {
            return _context.Genres.Include(g => g.Video).ToList();
        }
    }
}
