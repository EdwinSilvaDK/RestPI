using System;
namespace VideoAppBLL.BO
{
    public class RentalBO
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public VideoBO Video { get; set; }
    }
}
