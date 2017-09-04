using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repository
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        private static List<Video> Videos = new List<Video>();
        private static int Id = 1;

        public Video Create(Video vid)
        {
            Video newVid;
            Videos.Add(newVid = new Video()
            {
                Id = Id++,
                Autor = vid.Autor,
                Name = vid.Name,
                Length = vid.Length,


            });
            return newVid;
        }

        public Video Delete(int Id)
        {
            var vid = Videos.FirstOrDefault(x => x.Id == Id);


            Videos.Remove(vid);

            return vid;



        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.Id == Id);

        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }
    }
}
