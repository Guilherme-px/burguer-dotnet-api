using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deliveryAPI.Domain.Entities.Users;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [StringLength(10)]
    public string CEP { get; set; } = null!;

    [StringLength(100)]
    public string Street { get; set; } = null!;

    [StringLength(10)]
    public string StreetNumber { get; set; } = null!;

    [StringLength(100)]
    public string Neighborhood { get; set; } = null!;

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }
}
