using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AdsPal.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string? Photo { get; set; }
    public string? Address { get; set; }
    public string? UnitNo { get; set; }
    public string? PostalCode { get; set; }
    public string CountryCode { get; set; } = null!;
    public short CityId { get; set; }
    public byte UserTypeId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public byte Status { get; set; }
}
public enum UserType
{
    User, Admin
}
public enum UserStatus
{
    NotConfirmed, Active, Locked
}