using System;
using VideoAppBLL.BO;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converter
{
    public class VideoConverter
    {
        public VideoConverter()
        {
        }

        internal Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                Autor = vid.Autor,
                Name = vid.Name,
                Length = vid.Length


            };

        }
        internal VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                Autor = vid.Autor,
                Name = vid.Name,
                Length = vid.Length


            };

        }


    }
}
