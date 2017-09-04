using System;

namespace VideoAppBLL.BO
{
    public class VideoBO
    {

        public int Id { get; set; }
        public string Autor { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public String FullName
        {
            get
            { return $" {Autor}: {Name}"; }
        }
    }
}