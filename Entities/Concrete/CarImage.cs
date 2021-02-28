using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class CarImage:IEntity
    {
        public int ImagesId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime ImagesDate { get; set; }
    }
}
