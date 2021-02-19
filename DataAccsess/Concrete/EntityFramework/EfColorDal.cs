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
    public class EfColorDal : EfEntityRepositoryBase<Color, ReCapContext>, IColorDal
    {
        public List<GetColorsByColorId>GetColorsByColorIds()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from cs in context.Colors
                             join c in context.Cars
                             on cs.ColorId equals c.ColorId
                             select new GetColorsByColorId { ColorId =cs.ColorId, ColorName = cs.ColorName,Description=c.Description };
                return result.ToList();

            }
        }

    }
}
