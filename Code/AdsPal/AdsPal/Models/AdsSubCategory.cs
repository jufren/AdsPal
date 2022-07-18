using System;
using System.Collections.Generic;

namespace AdsPal.Models
{
    public partial class AdsSubCategory
    {
        public AdsSubCategory()
        {
            Ads = new HashSet<Ad>();
        }

        public short SubCategoryId { get; set; }
        public short CategoryId { get; set; }
        public string Description { get; set; } = null!;

        public virtual AdsCategory Category { get; set; } = null!;
        public virtual ICollection<Ad> Ads { get; set; }
    }
}
