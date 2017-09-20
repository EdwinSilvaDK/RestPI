using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace VideoAppBLL.BO
{
    public class VideoBO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int pricePrDay { get; set; }
        public List<GenreBO> Genres { get; set; }
        public List<RentalBO> Rentals { get; set; }




        public String TitlePrice
        {
            get
            { return $" Title: {Title}, Price: {pricePrDay}"; }
        }
    }
}