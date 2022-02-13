namespace ApiTesting
{

    public class BookingDates
    {
        public string checkIn { get; set; }
        public string checkOut { get; set; }
    }

    public class GetBooking
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int totalPrice { get; set; }
        public bool depositPaid { get; set; }
        public BookingDates bookingDates { get; set; }
        public string additionalNeeds { get; set; }
    }
}