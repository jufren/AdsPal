using System;
using System.Collections.Generic;

namespace AdsPal.Models
{
    public partial class AdsCorrespondence
    {
        public Guid ChatCorrespondenceId { get; set; }
        public string FromUserId { get; set; } = null!;
        public string ToUserId { get; set; } = null!;
        public long AdsId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual Ad Ads { get; set; } = null!;
    }
}
