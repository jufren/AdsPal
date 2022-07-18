using System;
using System.Collections.Generic;
using AdsPal.Areas.Identity.Data;
namespace AdsPal.Models
{
    public partial class City
    {
        public City()
        {
            Ads = new HashSet<Ad>();
            Users = new HashSet<ApplicationUser>();
        }

        public short CityId { get; set; }
        public string CityName { get; set; } = null!;

        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
