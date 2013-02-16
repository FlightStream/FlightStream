using System.Data.Entity;

namespace FlightStream.Models
{
    public class FlightStreamContext : DbContext
    {
        public DbSet<Aircraft> Aircrafts { set; get; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<AircraftTemplate> AircraftTemplates { get; set; }
    }

    
}