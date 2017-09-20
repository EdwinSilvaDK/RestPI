using System;
namespace VideoAppDAL.Entities
{
    public class Genre
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}
