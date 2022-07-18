using System;
using System.Collections.Generic;

namespace AdsPal.Models
{
    public partial class AdsCategory
    {
        public AdsCategory()
        {
            AdsSubCategories = new HashSet<AdsSubCategory>();
        }

        public short CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<AdsSubCategory> AdsSubCategories { get; set; }
    }
}
