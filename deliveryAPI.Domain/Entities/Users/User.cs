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
    [Column(TypeName = "VARCHAR")]
    public string Password { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string CEP { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Street { get; set; } = null!;

    [Required]
    public int StreetNumber { get; set; }

    [Required]
    [StringLength(100)]
    public string Neighborhood { get; set; } = null!;

    public bool IsAdmin { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }
}