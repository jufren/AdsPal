using AdsPal.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace AdsPal.Models
{
    public partial class Ad
    {
        public Ad()
        {
            AdsCorrespondences = new HashSet<AdsCorrespondence>();
            AdsMedia = new HashSet<AdsMedia>();
            AdsPaymentHistories = new HashSet<AdsPaymentHistory>();
        }

        public long AdsId { get; set; }
        public string UserId { get; set; } = null!;
        public string Details { get; set; } = null!;
        public short SubCategoryId { get; set; }
        public short CityId { get; set; }
        public byte ConditionId { get; set; }
        public string Brand { get; set; } = null!;
        public byte Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual City City { get; set; } = null!;
        
        public virtual AdsSubCategory SubCategory { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<AdsCorrespondence> AdsCorrespondences { get; set; }
        public virtual ICollection<AdsMedia> AdsMedia { get; set; }
        public virtual ICollection<AdsPaymentHistory> AdsPaymentHistories { get; set; }
    }
    public enum AdsStatus
    {
        Draft, Active, Expired, Closed
    }
    public enum AdsCondition
    {
        New, Used
    }
}
