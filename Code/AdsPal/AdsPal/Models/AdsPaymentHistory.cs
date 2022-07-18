using System;
using System.Collections.Generic;

namespace AdsPal.Models
{
    public partial class AdsPaymentHistory
    {
        public long AdsPaymentId { get; set; }
        public byte AdsPaymentOptionId { get; set; }
        public long AdsId { get; set; }
        public decimal Amount { get; set; }
        public byte PaymentMode { get; set; }
        public string? CreditCardNo { get; set; }
        public string? CryptoTransactionNo { get; set; }
        public string? CryptoAddress { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Ad Ads { get; set; } = null!;
        public virtual AdsPaymentOption AdsPaymentOption { get; set; } = null!;
    }
}
