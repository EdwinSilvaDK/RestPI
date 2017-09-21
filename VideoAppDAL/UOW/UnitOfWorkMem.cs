using System;
using VideoAppDAL.Context;
using VideoAppDAL.Repository;

namespace VideoAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        private VideoAppContext context;
        public IVideoRepository VideoRepository { get; internal set; }

        public IGenreRepository GenreRepository { get; internal set; }

        public IRentalRepository RentalRepository { get; internal set; }


        public UnitOfWorkMem()
        {
            context = new VideoAppContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
            GenreRepository = new GenreRepository(context);
            RentalRepository = new RentalRepository(context);

        }


        public int Complete()
        {
            return context.SaveChanges();

        }

        public void Dispose()
        {
            context.Dispose();
        }


    }
}
