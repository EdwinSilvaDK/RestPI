using System;
using System.Collections.Generic;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IVideoRepository
    {
        //Create
        Video Create(Video vid);

        //Read
        List<Video> GetAll();
        Video Get(int Id);

        //Update - 
        //No update method, thats the job of the unit of work(UOW)

        //Delete
        Video Delete(int Id);


    }
}
