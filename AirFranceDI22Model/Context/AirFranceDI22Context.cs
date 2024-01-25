using AirFranceDI22Model.Dao;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AirFranceDI22Model.Context;
public class AirFranceDI22Context(DbContextOptions<AirFranceDI22Context> options) 
    : IdentityDbContext<User>(options)
{
    public DbSet<Aeroport> Aeroports { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Compagnie> Compagnies { get; set; }
    public DbSet<Passager> Passagers { get; set; }
    public DbSet<Personne> Personnes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Ville> Villes { get; set; }
    public DbSet<Vol> Vols { get; set; }

}


public class AirFranceDI22ContextFactory : IDesignTimeDbContextFactory<AirFranceDI22Context>
{
    public AirFranceDI22Context CreateDbContext(string[] args)
    {
        var connexionString = "server=localhost;port=3306;userid=root;password=;database=AirFranceDI22;";
        var optionsBuilder = new DbContextOptionsBuilder<AirFranceDI22Context>();
        optionsBuilder.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString));

        return new AirFranceDI22Context(optionsBuilder.Options);
    }
}