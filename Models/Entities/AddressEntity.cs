using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Entities;
[PrimaryKey(nameof(AddressId))]


public class AddressEntity
{
    public int AddressId { get; set; }
    [Required]
    public string StreetName { get; set; } = null!;
    [Required]
    public string PostalCode { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;
    [Required]
    public string Country { get; set; } = null!;
    public ICollection<UserAddressEntity> Users { get; set; } = new HashSet<UserAddressEntity>();
}

