using BitrateCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace BitrateCalculator.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Transcoder> Transcoder { get; set; }
    public DbSet<NIC> NiC { get; set; }
}
