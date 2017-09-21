using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppBLL.BO;
using VideoAppBLL.Converter;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    public class RentalService : IRentalInterface
    {

        RentalConverter conv = new RentalConverter();
        private DALFacade _facade;

        public RentalService(DALFacade facade)
        {
            _facade = facade;
        }

        public List<RentalBO> AddGenre(List<RentalBO> Rents)
        {
            using (var uow = _facade.UnitOfWork)
            {

                foreach (var Ren in Rents)
                {
                    var newRen = uow.RentalRepository.Create(conv.Convert(Ren));

                }

                uow.Complete();

                return Rents;
            }
        }

        public RentalBO Create(RentalBO Ren)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Create(conv.Convert(Ren));
                uow.Complete();
                return conv.Convert(rentalEntity);
            }
        }

        public RentalBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(rentalEntity);
            }
        }

        public RentalBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Get(Id);

                return conv.Convert(rentalEntity);
            }

        }

        public List<RentalBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalList = uow.RentalRepository.GetAll().Select(conv.Convert).ToList();
                return rentalList;
            }
        }

        public RentalBO Update(RentalBO Ren)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var rentalEntity = uow.RentalRepository.Get(Ren.Id);
                if (rentalEntity == null)
                {
                    throw new InvalidOperationException("Rental not found");
                }
                rentalEntity.Id = Ren.Id;
                rentalEntity.To = Ren.To;
                rentalEntity.From = Ren.From;
                uow.Complete();

                return conv.Convert(rentalEntity);

            }
        }

    }
}
