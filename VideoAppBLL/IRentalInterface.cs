using System;
using System.Collections.Generic;
using VideoAppBLL.BO;
namespace VideoAppBLL
{
    public interface IRentalInterface
    {
        RentalBO Create(RentalBO Ren);
        List<RentalBO> AddGenre(List<RentalBO> Rens);
        List<RentalBO> GetAll();
        RentalBO Get(int Id);
        RentalBO Update(RentalBO Ren);
        RentalBO Delete(int Id);

    }
}
