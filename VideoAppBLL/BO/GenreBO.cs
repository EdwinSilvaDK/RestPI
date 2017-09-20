using System;
using System.Collections.Generic;
namespace VideoAppBLL.BO
{
    public class GenreBO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<VideoBO> Videos { get; set; }

    }
}
