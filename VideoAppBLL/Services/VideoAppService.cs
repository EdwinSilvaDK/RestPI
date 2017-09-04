
using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppDAL;
using VideoAppDAL.Entities;
using VideoAppBLL.BO;
using VideoAppBLL.Converter;

namespace VideoAppBLL.Services
{
    public class VideoAppService : IVideoAppInterface
    {
        VideoConverter videoConv = new VideoConverter();
        DALFacade facade;
        IVideoRepository repo;
        public VideoAppService(DALFacade facade)
        {

            this.facade = facade;
        }

        public List<Video> AddVideos(List<Video> vids)
        {

            using (var uow = facade.UnitOfWork)
            {

                foreach (var vid in vids)
                {
                    var newVid = uow.VideoRepository.Create(vid);

                }

                uow.Complete();

                return vids;
            }
        }

        public List<VideoBO> AddVideos(List<VideoBO> vids)
        {
            throw new NotImplementedException();
        }

        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(videoConv.Convert(vid));
                uow.Complete();

                return videoConv.Convert(newVid);
            }

        }

        public Video Create(Video vid)
        {
            throw new NotImplementedException();
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();

                return videoConv.Convert(newVid);
            }

        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return videoConv.Convert(uow.VideoRepository.Get(Id));

            }


        }
        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll().Select(v => videoConv.Convert(v)).ToList();



            }
        }

        public VideoBO Update(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var VideoFromDB = uow.VideoRepository.Get(vid.Id);
                if (VideoFromDB == null)
                {
                    throw new InvalidOperationException("Video not found");
                }
                VideoFromDB.Autor = vid.Autor;
                VideoFromDB.Name = vid.Name;
                VideoFromDB.Length = vid.Length;
                VideoFromDB.Id = vid.Id;
                return videoConv.Convert(VideoFromDB);
            }
        }

        public VideoBO Update(VideoBO vid)
        {
            throw new NotImplementedException();
        }




    }
}

