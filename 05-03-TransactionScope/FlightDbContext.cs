using System.Data.Entity;

namespace _05_03_TransactionScope
{
    [DbConfigurationType(typeof(HotelFlightConfiguration))]
    public class FlightDbContext : DbContext
    {
        public FlightDbContext() : base("name=flightConnection")
        {

        }
        public DbSet<FlightBooking> FlightBooking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FlightBookingMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}