using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SongManager.Models
{
    public class SongManagerContext : DbContext
    {
        public SongManagerContext (DbContextOptions<SongManagerContext> options)
            : base(options)
        {
        }

        public DbSet<SongManager.Models.Song> Song { get; set; }
    }
}
