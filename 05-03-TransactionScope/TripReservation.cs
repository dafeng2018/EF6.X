using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_03_TransactionScope
{
    public class TripReservation
    {
        public FlightBooking Flight { get; set; }
        public Reservation Hotel { get; set; }
    }
}
