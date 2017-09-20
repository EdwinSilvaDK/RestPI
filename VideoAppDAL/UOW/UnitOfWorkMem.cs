using System;
using VideoAppDAL.Context;
using VideoAppDAL.Repository;

namespace VideoAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }

        public IGenreRepository GenreRepository { get; internal set; }

        private VideoAppContext context;
        public UnitOfWorkMem()
        {
            context = new VideoAppContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
            GenreRepository = new GenreRepository(context);
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
