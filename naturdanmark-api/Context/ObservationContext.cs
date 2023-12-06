using Microsoft.EntityFrameworkCore;
using naturdanmark_api.Models;

namespace naturdanmark_api.Context
{
    public class ObservationContext:DbContext
    {
        public ObservationContext(DbContextOptions<ObservationContext> options) : base(options) 
        { 
        
        }

        public DbSet<Observation> Observations { get; set; }
        public DbSet<Image> Observaitonfotos { get; set; }
    }
}
