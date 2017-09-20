using System;
using System.Collections.Generic;
using VideoAppBLL.BO;
namespace VideoAppBLL
{
    public interface IGenreInterface
    {
        GenreBO Create(GenreBO gen);
        List<GenreBO> AddGenre(List<GenreBO> gens);
        List<GenreBO> GetAll();
        GenreBO Get(int Id);
        GenreBO Update(GenreBO gen);
        GenreBO Delete(int Id);

    }
}
