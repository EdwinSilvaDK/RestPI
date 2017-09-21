using System;
using System.Collections.Generic;
namespace VideoAppDAL.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Video Video { get; set; }
    }
}
