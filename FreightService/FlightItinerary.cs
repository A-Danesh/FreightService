// See https://aka.ms/new-console-template for more information

namespace FreightService
{
    public class FlightItinerary
    {
        public string OrderNumber { get; set; }

        public string? FlightNumber { get; set; }
        public string Departure { get; set; }
        public string? Arrival { get; set; }
        public int? Day { get; set; }
    }

}