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
            return new Rental()
            {
                Id = Ren.Id,
                From = Ren.From,
                To = Ren.To
            };

        }
        internal RentalBO Convert(Rental Ren)
        {
            return new RentalBO()
            {
                Id = Ren.Id,
                From = Ren.From,
                To = Ren.To

            };

        }


    }
}
