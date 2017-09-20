using System;
using System.Collections.Generic;
using VideoAppBLL.BO;
using VideoAppDAL;
using VideoAppBLL.Converter;
using System.Linq;

namespace VideoAppBLL.Services
{
    public class GenreService : IGenreInterface
    {
        GenreConverter conv = new GenreConverter();
        DALFacade _facade;
        public GenreService(DALFacade facade)
        {
            _facade = facade;

        }
        public List<GenreBO> AddGenre(List<GenreBO> gens)
        {
            using (var uow = _facade.UnitOfWork)
            {

                foreach (var gen in gens)
                {
                    var newGen = uow.GenreRepository.Create(conv.Convert(gen));

                }

                uow.Complete();

                return gens;
            }
        }

        public GenreBO Create(GenreBO gen)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Create(conv.Convert(gen));
                uow.Complete();
                return conv.Convert(genreEntity);
            }
        }

        public GenreBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(genreEntity);
            }
        }

        public GenreBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Get(Id);
                genreEntity.Video = uow.VideoRepository.Get(genreEntity.VideoId);
                return conv.Convert(genreEntity);
            }

        }

        public List<GenreBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreList = uow.GenreRepository.GetAll().Select(conv.Convert).ToList();
                return genreList;
            }
        }

        public GenreBO Update(GenreBO gen)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Get(gen.Id);
                if (genreEntity == null)
                {
                    throw new InvalidOperationException("Genre not found");
                }
                genreEntity.Name = gen.Name;
                genreEntity.Id = gen.Id;
                uow.Complete();
                genreEntity.Video = uow.VideoRepository.Get(genreEntity.VideoId);
                return conv.Convert(genreEntity);

            }
        }
    }
}
