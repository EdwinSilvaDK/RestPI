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
            if (vid == null) { return null; }

            return new Video()
            {
                Id = vid.Id,
                Title = vid.Title,
                pricePrDay = vid.pricePrDay,


            };

        }
        internal VideoBO Convert(Video vid)
        {
            if (vid == null) { return null; }

            return new VideoBO()
            {
                Id = vid.Id,
                Title = vid.Title,
                pricePrDay = vid.pricePrDay,


            };

        }


    }
}
