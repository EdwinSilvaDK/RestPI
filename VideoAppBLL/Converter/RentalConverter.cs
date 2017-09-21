using System;
using VideoAppBLL.BO;
using VideoAppDAL.Entities;
namespace VideoAppBLL.Converter
{
    public class RentalConverter
    {
        public RentalConverter()
        {
        }
        internal Rental Convert(RentalBO Ren)
        {
            if (Ren == null) { return null; }
            return new Rental()
            {
                Id = Ren.Id,
                From = Ren.From,
                To = Ren.To,
                Video = new VideoConverter().Convert(Ren.Video)
            };

        }
        internal RentalBO Convert(Rental Ren)
        {
            if (Ren == null) { return null; }
            return new RentalBO()
            {
                Id = Ren.Id,
                From = Ren.From,
                To = Ren.To,
                Video = new VideoConverter().Convert(Ren.Video)


            };

        }


    }
}
