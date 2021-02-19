using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class GetBrandsByBrandId
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
    }
}
