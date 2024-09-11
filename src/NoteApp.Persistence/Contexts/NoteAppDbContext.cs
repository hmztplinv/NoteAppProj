using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Entities;

namespace NoteApp.Persistence.Contexts;

public class NoteAppDbContext: DbContext
{
    public NoteAppDbContext(DbContextOptions<NoteAppDbContext> options): base(options)
    {
    }

    public DbSet<Note> Notes { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Note>().HasData(
            new Note { Id = Guid.NewGuid(), Title = "First Note", Content = "This is the content of the first note." },
            new Note { Id = Guid.NewGuid(), Title = "Second Note", Content = "This is the content of the second note." }
        );
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NoteAppDbContext).Assembly);
    }
    
}