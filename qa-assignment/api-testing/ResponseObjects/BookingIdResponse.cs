using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ResponseBody
{
    public class BookingId
    {
        [JsonPropertyName("bookingid")]
        public int bookingId { get; set; }
    }

    public class BookingIds
    {
        
        public JsonArrayAttribute bookingIds { get; set; }
    }
}