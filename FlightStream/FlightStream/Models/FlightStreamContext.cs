using System.Data.Entity;

namespace FlightStream.Models
{
    public class FlightStreamContext : DbContext
    {
        public DbSet<AircraftModel> AircraftModels { set; get; }

        public DbSet<PersonModel> PersonModels { get; set; }

        public DbSet<ClientModel> ClientModels { get; set; }

        public DbSet<AircraftTemplate> AircraftTemplates { get; set; }
    }

    
}