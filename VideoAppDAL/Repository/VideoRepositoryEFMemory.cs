using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repository
{
    public class VideoRepositoryEFMemory : IVideoRepository
    {

        VideoAppContext context;
        public VideoRepositoryEFMemory(VideoAppContext context)
        {
            this.context = context;
        }

        public Video Create(Video vid)
        {

            context.Videos.Add(vid);

            return vid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            context.Videos.Remove(vid);

            return vid;

        }

        public Video Get(int Id)
        {
            return context.Videos.FirstOrDefault(x => x.Id == Id);

        }

        public List<Video> GetAll()
        {
            return context.Videos.ToList();
        }
    }
}
