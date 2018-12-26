using System.Data.Entity;

namespace _05_03_TransactionScope
{
    [DbConfigurationType(typeof(HotelFlightConfiguration))]

    public class HotelDbContext : DbContext
    {
        public HotelDbContext() : base("name=reservationConnection")
        {

        }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReservationMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}