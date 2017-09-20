
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

        public List<VideoBO> AddVideos(List<VideoBO> vids)
        {

            using (var uow = facade.UnitOfWork)
            {

                foreach (var vid in vids)
                {
                    var newVid = uow.VideoRepository.Create(videoConv.Convert(vid));

                }

                uow.Complete();

                return vids;
            }
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

        public VideoBO Update(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var VideoFromDB = uow.VideoRepository.Get(vid.Id);
                if (VideoFromDB == null)
                {
                    throw new InvalidOperationException("Video not found");
                }
                VideoFromDB.Title = vid.Title;
                VideoFromDB.pricePrDay = vid.pricePrDay;
                VideoFromDB.Id = vid.Id;
                uow.Complete();
                return videoConv.Convert(VideoFromDB);
            }
        }


    }
}

