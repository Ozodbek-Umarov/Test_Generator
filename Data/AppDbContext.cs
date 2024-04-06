using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
{
    public DbSet<Option> Options { get; set; }
    public DbSet<Test> Tests { get; set; }
}
