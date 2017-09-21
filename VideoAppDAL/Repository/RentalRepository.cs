using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;
using VideoAppDAL.UOW;

namespace VideoAppDAL.Repository
{
    public class RentalRepository : IRentalRepository
    {
        VideoAppContext _context;


        public RentalRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Rental Create(Rental Ren)
        {
            if (Ren.Video != null)
            {
                _context.Entry(Ren.Video).State =
                    EntityState.Unchanged;
            }
            _context.Rentals.Add(Ren);
            return Ren;
        }

        public Rental Delete(int Id)
        {
            var Ren = Get(Id);
            _context.Rentals.Remove(Ren);
            return Ren;
        }

        public Rental Get(int Id)
        {
            return _context.Rentals.FirstOrDefault(r => r.Id == Id);

        }

        public List<Rental> GetAll()
        {
            return _context.Rentals.ToList();
        }
    }
}

