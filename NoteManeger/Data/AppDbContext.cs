using Microsoft.EntityFrameworkCore;
using NoteManeger.Models;

namespace NoteManeger.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Note> TableNote1 { get; set; }
    }
}
