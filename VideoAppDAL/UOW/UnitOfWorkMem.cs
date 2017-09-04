﻿using System;
using VideoAppDAL.Context;
using VideoAppDAL.Repository;

namespace VideoAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        private InMemoryContext context;
        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
        }


        public int Complete()
        {
            return context.SaveChanges();

        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
