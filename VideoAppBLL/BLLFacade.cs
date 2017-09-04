using System;
using VideoAppBLL.Services;
using VideoAppDAL;

namespace VideoAppBLL
{
    public class BLLFacade
    {

        public IVideoAppInterface VideoAppService
        {
            get { return new VideoAppService(new DALFacade()); }
        }

    }
}

