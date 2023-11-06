// See https://aka.ms/new-console-template for more information

namespace FreightService.Dto
{
    public interface IFlight
    {
        string FlightNumber { get; }
        string Departure { get; }
        string Arrival { get; }
        int Day { get; }

    }
}