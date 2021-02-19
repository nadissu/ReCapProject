using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class GetColorsByColorId:IDto
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }

        public string Description { get; set; }    
    }
}
