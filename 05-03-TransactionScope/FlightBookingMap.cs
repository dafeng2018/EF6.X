using System.Data.Entity.ModelConfiguration;

namespace _05_03_TransactionScope
{
    internal class FlightBookingMap : EntityTypeConfiguration<FlightBooking>
    {
        public FlightBookingMap()
        {
            HasKey(k => k.FlightID);
        }
    }
}