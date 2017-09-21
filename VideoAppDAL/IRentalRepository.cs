using System;
using System.Collections.Generic;
using VideoAppDAL.Entities;
namespace VideoAppDAL.UOW
{
    public interface IRentalRepository
    {
        //Create
        Rental Create(Rental Ren);

        //Read
        List<Rental> GetAll();
        Rental Get(int Id);

        //Update - 
        //No update method, thats the job of the unit of work(UOW)

        //Delete
        Rental Delete(int Id);


    }
}
