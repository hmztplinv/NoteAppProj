using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NoteApp.Persistence.Contexts;

public class NoteAppDbContextFactory : IDesignTimeDbContextFactory<NoteAppDbContext>
{
    public NoteAppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../NoteApp.WebApp")) // WebAPI'nin dizinine yönlendir
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<NoteAppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new NoteAppDbContext(optionsBuilder.Options);
    }
}