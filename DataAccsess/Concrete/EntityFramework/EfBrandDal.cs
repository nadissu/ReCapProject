using Core.DataAccess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapContext>, IBrandDal
    {


        public List<GetBrandsByBrandId> GetBrandsByBrandId()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars
                             on b.BrandId equals c.BrandId
                             select new GetBrandsByBrandId { BrandId = b.BrandId, BrandName = b.BrandName,ModelYear=c.ModelYear };
                return result.ToList();

            }
        }
    }
}
