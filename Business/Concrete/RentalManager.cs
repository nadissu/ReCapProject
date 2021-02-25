using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
           _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            var result = _rentalDal.GetAll(r => r.RentalId == rental.RentalId);
            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalDeliverError);
            }
            else
            {
                return new SuccessResult(Messages.RentalAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
