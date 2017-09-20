using System;
using System.Collections.Generic;
using VideoAppDAL.Entities;
namespace VideoAppDAL
{
    public interface IGenreRepository
    {
        //Create
        Genre Create(Genre gen);

        //Read
        List<Genre> GetAll();
        Genre Get(int Id);

        //Update - 
        //No update method, thats the job of the unit of work(UOW)

        //Delete
        Genre Delete(int Id);




    }
}
