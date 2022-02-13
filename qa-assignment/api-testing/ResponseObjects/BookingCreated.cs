using System.Text.Json.Serialization;

namespace ApiTesting
{
    class BookingCreated
    {
        [JsonPropertyName("bookingid")]
        public int BookingId { get; set; }

        [JsonPropertyName("booking")]
        public GetBooking Booking { get; set; }
    }
}