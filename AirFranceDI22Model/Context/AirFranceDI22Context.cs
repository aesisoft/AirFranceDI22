using AirFranceDI22Model.Dao;
using Microsoft.EntityFrameworkCore;

namespace AirFranceDI22Model.Context;
public class AirFranceDI22Context : DbContext
{
    public AirFranceDI22Context() { }

    public AirFranceDI22Context(DbContextOptions<AirFranceDI22Context> options) : base(options)
    {
    }
    public DbSet<Aeroport> Aeroports { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Compagnie> Compagnies { get; set; }
    public DbSet<Passager> Passagers { get; set; }
    public DbSet<Personne> Personnes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Ville> Villes { get; set; }
    public DbSet<Vol> Vols { get; set; }

}
