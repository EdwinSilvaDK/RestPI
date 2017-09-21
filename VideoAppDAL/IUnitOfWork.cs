using System;
using VideoAppDAL.UOW;
namespace VideoAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        IGenreRepository GenreRepository { get; }
        IRentalRepository RentalRepository { get; }

        int Complete();
    }
}
