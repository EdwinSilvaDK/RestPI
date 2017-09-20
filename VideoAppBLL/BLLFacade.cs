using System;
using VideoAppBLL.Services;
using VideoAppDAL;
using VideoAppDAL.Entities;

namespace VideoAppBLL
{
    public class BLLFacade
    {

        public IVideoAppInterface VideoAppService
        {
            get { return new VideoAppService(new DALFacade()); }
        }

        public IGenreInterface GenreService
        {
            get { return new GenreService(new DALFacade()); }
        }

    }
}

