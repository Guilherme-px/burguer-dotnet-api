using System;

namespace burguerAPI.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string CEP { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string Neighborhood { get; set; } = null!;
}
