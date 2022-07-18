using System;
using System.Collections.Generic;

namespace AdsPal.Models
{
    public partial class AdsPaymentOption
    {
        public AdsPaymentOption()
        {
            AdsPaymentHistories = new HashSet<AdsPaymentHistory>();
        }

        public byte AdsPaymentOptionId { get; set; }
        public string AdsPaymentOptionLabel { get; set; } = null!;
        public decimal AdsPaymentOptionCharge { get; set; }
        public short NoOfDaysSubscription { get; set; }

        public virtual ICollection<AdsPaymentHistory> AdsPaymentHistories { get; set; }
    }
}
