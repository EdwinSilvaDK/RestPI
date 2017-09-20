using System;
using VideoAppBLL.BO;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converter
{
    public class GenreConverter
    {
        public GenreConverter()
        {
        }
        internal Genre Convert(GenreBO Gen)
        {
            return new Genre()
            {
                Id = Gen.Id,
                Name = Gen.Name







            };

        }
        internal GenreBO Convert(Genre Gen)
        {
            return new GenreBO()
            {
                Id = Gen.Id,
                Name = Gen.Name,


            };

        }

    }
}
