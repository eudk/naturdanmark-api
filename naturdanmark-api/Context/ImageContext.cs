using Microsoft.EntityFrameworkCore;
using naturdanmark_api.Models;

namespace naturdanmark_api.Context
{
    public class ImageContext:DbContext
    {
        public ImageContext(DbContextOptions<ImageContext> options) : base(options) 
        { 
        
        }

        public DbSet<Observation> Observations { get; set; }
    }
}
