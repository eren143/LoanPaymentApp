using System;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AraOdemeContext : DbContext
{
    public AraOdemeContext(DbContextOptions options) : base(options){}
    
    public DbSet<OdemePlani> AraOdemePlanlari { get; set; }
}

