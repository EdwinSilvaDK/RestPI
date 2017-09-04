using System;
using System.Collections.Generic;
using VideoAppBLL.BO;

namespace VideoAppBLL
{
    public interface IVideoAppInterface
    {
        VideoBO Create(VideoBO vid);
        List<VideoBO> AddVideos(List<VideoBO> vids);
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        VideoBO Update(VideoBO vid);
        VideoBO Delete(int Id);


    }
}
