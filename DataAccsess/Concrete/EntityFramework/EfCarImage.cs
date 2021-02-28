using Core.DataAccess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfCarImage:EfEntityRepositoryBase<CarImage,ReCapContext>,ICarImageDal
    {
    }
}
