using System;
using System.Collections.Generic;

namespace AdsPal.Models
{
    public partial class AdsMedia
    {
        public Guid AdsImageId { get; set; }
        public long AdsId { get; set; }
        public string AdsImageFileType { get; set; } = null!;
        public string OriginalFileName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual Ad Ads { get; set; } = null!;
    }
}
