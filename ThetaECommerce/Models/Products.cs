using System;
using System.Collections.Generic;

namespace ThetaECommerce.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Categoryids { get; set; }
        public string Description { get; set; }
        public decimal? Saleprice { get; set; }
        public string Discount { get; set; }
        public DateTime? Discountexpiry { get; set; }
        public string Images { get; set; }
        public double? Stock { get; set; }
        public string Status { get; set; }
        public string Extras { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
