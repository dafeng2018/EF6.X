using System.Data.Entity.ModelConfiguration;

namespace _05_03_TransactionScope
{
    internal class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            HasKey(k => k.BookingID);
            Property(p => p.BookingID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
        }
    }
}