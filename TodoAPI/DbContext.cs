using Microsoft.EntityFrameworkCore;
using TodoAPI.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ToDo> Todos { get; set; }
}