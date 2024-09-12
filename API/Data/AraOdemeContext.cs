using System;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AraOdemeContext : DbContext
{
    public AraOdemeContext(DbContextOptions<AraOdemeContext> options) : base(options) { }
    
    public DbSet<OdemePlani> AraOdemePlanlari { get; set; }
    public DbSet<OdemeSatiri> OdemeSatirlari { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OdemePlani>()
            .HasMany(o => o.Satirlar)
            .WithOne(s => s.OdemePlani)
            .HasForeignKey(s => s.OdemePlaniId);
    }
}

