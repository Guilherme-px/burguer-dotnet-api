using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using burguerAPI.Domain.Entities;

namespace burguerAPI.Infrastructure.Context;

public class BurguerDbContext : DbContext
{
    public BurguerDbContext(DbContextOptions<BurguerDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
