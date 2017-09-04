using System;
using VideoAppDAL.Repository;
using VideoAppDAL.UOW;

namespace VideoAppDAL
{
    public class DALFacade
    {

        public DALFacade()
        {
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMem();
            }
        }
    }
}
