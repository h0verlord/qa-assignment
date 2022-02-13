using System.Text.Json.Serialization;

public class BookingDates
{
    [JsonPropertyName("checkin")]
    public string CheckIn { get; set; }

    [JsonPropertyName("checkout")]
    public string CheckOut { get; set; }

    public BookingDates(string checkIn, string checkOut)
    {
        this.CheckIn = checkIn;
        this.CheckOut = checkOut;
    }
}

public class CreateBooking
{
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastname")]
    public string LastName { get; set; }

    [JsonPropertyName("totalprice")]
    public int TotalPrice { get; set; }

    [JsonPropertyName("depositpaid")]
    public bool DepositPaid { get; set; }

    [JsonPropertyName("bookingdates")]
    public BookingDates BookingDates { get; set; }

    [JsonPropertyName("additionalneeds")]
    public string AdditionalNeeds { get; set; }

    public CreateBooking(
        string firstName = "John",
        string lastName = "Doe",
        int totalPrice = 123,
        bool depositPaid = false,
        string checkIn = "2020-01-01",
        string checkOut = "2020-02-01",
        string additionalNeeds = "Yes, lots"
    )
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.TotalPrice = totalPrice;
        this.DepositPaid = depositPaid;
        this.BookingDates = new BookingDates(checkIn, checkOut);
        this.AdditionalNeeds = additionalNeeds;
    }
}

